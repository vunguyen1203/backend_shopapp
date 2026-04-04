using backend_shopapp.Dtos;
using backend_shopapp.Dtos.User;
using backend_shopapp.Exceptions;
using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace backend_shopapp.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly IDatabase _cache;

        public UserService(AppDbContext db,
            IJwtService jwtService,
            IEmailService emailService,
            IConnectionMultiplexer connection)
        {
            _db = db;
            _jwtService = jwtService;
            _emailService = emailService;
            _cache = connection.GetDatabase();
        }

        public async Task Create(CreateUserRequest request)
        {
            bool userExist = await _db.Users.AnyAsync(u => u.Email == request.Email);
            if (userExist) throw new ConflictException("Email is exist");

            _db.Users.Add(new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            });
            await _db.SaveChangesAsync();

            await _emailService.SendEmail(
                request.Email,
                "Confirm registration",
                $@"<h3>Hello {request.Name}</h3><p>Account has been created</p>"
            );

            await _cache.StringIncrementAsync("users:version");
        }

        public async Task<(string accessToken, string refreshToken)> Login(LoginRequest request)
        {
            var user = await _db.Users
                .Where(u => u.Email == request.Email)
                .Select(u => new User
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,
                    Role = u.Role,
                    Password = u.Password,
                    IsBlocked = u.IsBlocked,
                }).FirstOrDefaultAsync();

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                throw new UnauthorizedException("Invalid email or password");

            if (user.IsBlocked) 
                throw new ForbiddenException("User has been blocked");

            string accessToken = _jwtService.GenerateAccessToken(user);
            string refreshToken = _jwtService.GenerateRefreshToken();

            string hashedRefreshToken = HashToken(refreshToken);

            await _cache.StringSetAsync($"refresh_token:{hashedRefreshToken}", user.Id, TimeSpan.FromDays(7));
            await _cache.SetAddAsync($"user_refresh_tokens:{user.Id}", hashedRefreshToken);

            return (accessToken, refreshToken);
        }

        public async Task Logout(string userId, string refreshToken)
        {
            string hashedToken = HashToken(refreshToken);

            string key = $"user_refresh_tokens:{userId}";
            var token = await _cache.StringGetAsync($"refresh_token:{hashedToken}");
            var tokens = await _cache.SetMembersAsync(key);

            if (token.IsNullOrEmpty || tokens.IsNullOrEmpty()) 
                throw new NotFoundException("Refresh Token not found");

            await _cache.KeyDeleteAsync($"refresh_token:{hashedToken}");
            await _cache.SetRemoveAsync(key, hashedToken);
        }

        public async Task LogoutAll(string userId)
        {
            string key = $"user_refresh_tokens:{userId}";
            var tokens = await _cache.SetMembersAsync(key);
            if (tokens.IsNullOrEmpty()) 
                throw new NotFoundException("Refresh Token not found");

            foreach (var token in tokens)
            {
                await _cache.KeyDeleteAsync($"refresh_token:{token}");
            }

            await _cache.KeyDeleteAsync(key);
        }

        public async Task<string> RefreshToken(string refreshToken)
        {
            string hashedToken = HashToken(refreshToken);

            var stored = await _cache.StringGetAsync($"refresh_token:{hashedToken}");

            if (stored.IsNullOrEmpty)
                throw new UnauthorizedException("Refresh token has expired or not found");

            var user = await _db.Users.FindAsync(stored.ToString());
            if (user == null) throw new NotFoundException("User not found");

            string accessToken = _jwtService.GenerateAccessToken(user);

            return accessToken;
        }

        public async Task ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null) throw new NotFoundException("User not found");

            string token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(8));

            await _cache.StringSetAsync($"password_reset_token:{token}", request.Email, TimeSpan.FromMinutes(15));

            await _emailService.SendEmail(
                request.Email,
                "Reset Password",
                $@"
                Use the verification code below to reset your password.<br>
                Code: {token}.<br>
                This code will expire in 15 minutes.
                "
            );
        }

        public async Task ResetPassword(ResetPasswordRequest request)
        {
            var stored = await _cache.StringGetAsync($"password_reset_token:{request.Token}");
            if (stored.IsNullOrEmpty)
                throw new BadRequestException("Invalid or expired token");

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == stored.ToString());
            if (user == null) throw new NotFoundException("User not found");

            user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(string currentId, string currentRole, string targetId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == targetId);
            if (user == null) throw new NotFoundException("User not found");

            if (!CanModify(currentId, currentRole, user))
                throw new ForbiddenException("Don't have permission to update this account");

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"user:{user.Id}");
            await _cache.StringIncrementAsync("users:version");
        }

        public async Task<List<UserResponse>> GetAll(QueryParameters param)
        {
            string keyVersion = "users:version";
            var version = await _cache.StringGetAsync(keyVersion);
            if (version.IsNullOrEmpty)
            {
                await _cache.StringIncrementAsync(keyVersion);
                version = 1;
            }

            string key = $"users:v{version}:{param.Search}:{param.Sort}:{param.Dir}:{param.Page}:{param.Size}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<List<UserResponse>>(stored);

            var query = _db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.Search))
                query = query.Where(u => u.Name.Contains(param.Search) || u.Email.Contains(param.Search));

            query = param.Dir == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, param.Sort))
                : query.OrderBy(e => EF.Property<object>(e, param.Sort));

            var users = await query
                .Skip((param.Page - 1) * param.Size)
                .Take(param.Size)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                }).ToListAsync();

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(users), TimeSpan.FromMinutes(10));

            return users;
        }

        public async Task<UserResponse?> GetById(string id)
        {
            string key = $"user:{id}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<UserResponse>(stored);

            var user = await _db.Users
                .Where(u => u.Id == id)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                }).FirstOrDefaultAsync();
            if (user == null) throw new NotFoundException("User not found");

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(user), TimeSpan.FromMinutes(20));

            return user;
        }

        public async Task Update(string id, UpdateUserRequest request)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) throw new NotFoundException("User not found");

            if (!string.IsNullOrWhiteSpace(request.Name)) user.Name = request.Name;
            if (!string.IsNullOrWhiteSpace(request.Email)) user.Email = request.Email;
            if (!string.IsNullOrWhiteSpace(request.Password)) 
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"user:{user.Id}");
            await _cache.StringIncrementAsync("users:version");
        }

        public async Task UpdateByAdmin(string currentId, string currentRole, string targetId, UpdateUserByAdminRequest request)
        {
            var user = await _db.Users.FindAsync(targetId);
            if (user == null) throw new NotFoundException("User not found");

            if (!CanModify(currentId, currentRole, user))
                throw new ForbiddenException("Don't have permission to update this account");

            if (!string.IsNullOrWhiteSpace(request.Name)) user.Name = request.Name;
            if (!string.IsNullOrWhiteSpace(request.Email)) user.Email = request.Email;
            if (!string.IsNullOrWhiteSpace(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            if (user.Role == nameof(Roles.admin) || user.Role == nameof(Roles.mod))
            {
                if (!string.IsNullOrWhiteSpace(request.Role)) user.Role = request.Role;
                if (request.IsBlocked.HasValue) user.IsBlocked = request.IsBlocked.Value;
            }
            user.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"user:{user.Id}");
            await _cache.StringIncrementAsync("users:version");
        }

        private bool CanModify(string currentId, string currentRole, User target)
        {
            var cur = currentRole.ToLower();
            var tar = target.Role.ToLower();

            if (tar == nameof(Roles.admin) && currentId != target.Id)
                return false;

            if (cur == nameof(Roles.mod) && (tar == nameof(Roles.mod) || tar == nameof(Roles.admin)))
                return false;

            return true;
        }

        private string HashToken(string token)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
            return Convert.ToBase64String(bytes);
        }
    }
}
