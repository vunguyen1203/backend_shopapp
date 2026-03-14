using backend_shopapp.Dtos;
using backend_shopapp.Dtos.User;

namespace backend_shopapp.Interfaces
{
    public interface IUserService
    {
        Task<(string accessToken, string refreshToken)> Login(LoginRequest dto);
        Task Logout(string userId, string refreshToken);
        Task LogoutAll(string userId);
        Task ForgotPassword(ForgotPasswordRequest request);
        Task ResetPassword(ResetPasswordRequest request);
        Task<string> RefreshToken(string refreshToken);
        Task<List<UserResponse>> GetAll(QueryParameters param);
        Task<UserResponse?> GetById(string id);
        Task Create(CreateUserRequest request);
        Task Update(string id, UpdateUserRequest request);
        Task UpdateByAdmin(string? currentId, string? currentRole, string? targetId, UpdateUserByAdminRequest request);
        Task Delete(string currentId, string currentRole, string targetId);

    }
}
