using backend_shopapp.Dtos;
using backend_shopapp.Exceptions;
using backend_shopapp.Dtos.FeedBack;
using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace backend_shopapp.Services
{
    public class FeedBackService : IFeedBackService
    {
        private readonly AppDbContext _db;
        private readonly IDatabase _cache;

        public FeedBackService(AppDbContext db, IConnectionMultiplexer connection)
        {
            _db = db;
            _cache = connection.GetDatabase();
        }

        public async Task FeedBack(string userId, string productId, CreateFeedBackRequest request)
        {
            bool productExist = await _db.Products.AnyAsync(p => p.Id == productId);
            if (!productExist) throw new NotFoundException("Product not found");

            bool feedBackExist = await _db.FeedBacks
                .AnyAsync(f => f.UserId == userId && f.ProductId == productId);
            if (feedBackExist) throw new ConflictException("You have provided feedback on the product");

            _db.FeedBacks.Add(new FeedBack
            {
                UserId = userId,
                ProductId = productId,
                Content = request.Content,
                Rating = request.Rating,
            });
            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync($"feedbacks:{productId}:version");
        }

        public async Task ReplayFeedBack(string userId, string parentId, ReplayFeedBackRequest request)
        {
            var productId = await _db.FeedBacks
                .Where(f => f.Id == parentId && f.ParentId == null)
                .Select(f => f.ProductId)
                .FirstOrDefaultAsync();
            if (productId == null) throw new NotFoundException("FeedBack not found");

            _db.FeedBacks.Add(new FeedBack
            {
                UserId = userId,
                ProductId = productId,
                Content = request.Content,
                ParentId = parentId,
            });
            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync($"feedbacks:{productId}:version");
        }

        public async Task<List<FeedBackResponse>> GetAll(string productId, QueryParameters param)
        {
            bool productExist = await _db.Products.AnyAsync(p => p.Id == productId);
            if (!productExist) throw new NotFoundException("Product not found");

            string keyVersion = $"feedbacks:{productId}:version";
            var version = await _cache.StringGetAsync(keyVersion);
            if (version.IsNullOrEmpty)
            {
                await _cache.StringIncrementAsync(keyVersion);
                version = 1;
            }

            string key = $"feedbacks:{productId}:v{version}:{param.Sort}:{param.Dir}:{param.Page}:{param.Size}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty) 
                return JsonSerializer.Deserialize<List<FeedBackResponse>>(stored); 

            var query = _db.FeedBacks
                .AsNoTracking()
                .AsQueryable();

            query = param.Dir?.ToLower() == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, param.Sort))
                : query.OrderBy(e => EF.Property<object>(e, param.Sort));

            var feedBacks = await query
                .Where(r => r.ProductId == productId && r.ParentId == null)
                .Skip((param.Page - 1) * param.Size)
                .Take(param.Size)
                .Select(r => new FeedBackResponse
                {
                    Id = r.Id,
                    UserName = r.User.Name,
                    Content = r.Content,
                    Rating = r.Rating ?? 0,
                    CreatedAt = r.CreatedAt,
                    Replies = r.Replies
                        .OrderBy(r => r.CreatedAt)
                        .Select(x => new ReplayFeedBackResponse
                        {
                            Id = x.Id,
                            UserName = x.User.Name,
                            Content = x.Content,
                            CreatedAt = x.CreatedAt
                        })
                        .ToList()
                }).ToListAsync();

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(feedBacks), TimeSpan.FromMinutes(10));

            return feedBacks;
        }
    }
}
