using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Category;
using backend_shopapp.Exceptions;
using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace backend_shopapp.Services
{
    public class CategoryService : IService<CreateCategoryRequest, UpdateCategoryRequest, CategoryResponse>
    {
        private readonly AppDbContext _db;
        private readonly ISlugifyService _slugifyService;
        private readonly IDatabase _cache;

        public CategoryService(AppDbContext db,
          ISlugifyService slugifyService,
          IConnectionMultiplexer connection)
        {
            _db = db;
            _slugifyService = slugifyService;
            _cache = connection.GetDatabase();
        }

        public async Task Create(CreateCategoryRequest request)
        {
            bool categoryExist = await _db.Categories.AnyAsync(c => c.Name == request.Name);
            if (categoryExist) throw new ConflictException("Category is exist");

            _db.Categories.Add(new Category
            {
                Name = request.Name,
                Slug = _slugifyService.GenerateSlugify(request.Name)
            });

            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync("categories:version");
        }

        public async Task Delete(string id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null) throw new NotFoundException("Category not found");

            _db.Categories.Remove(category);

            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"category:{id}");
            await _cache.StringIncrementAsync("categories:version");
        }

        public async Task<List<CategoryResponse>> GetAll(QueryParameters param)
        {
            string keyVersion = "categories:version";
            var version = await _cache.StringGetAsync(keyVersion);
            if (version.IsNullOrEmpty)
            {
                await _cache.StringIncrementAsync(keyVersion);
                version = 1;
            }

            string key = $"categories:v{version}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<List<CategoryResponse>>(stored);

            var categories =  await _db.Categories.Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            }).ToListAsync();

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(categories), TimeSpan.FromMinutes(10));

            return categories;
        }

        public async Task<CategoryResponse?> GetById(string id)
        {
            string key = $"category:{id}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<CategoryResponse>(stored);

            var category = await _db.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).FirstOrDefaultAsync();
            if (category == null) throw new NotFoundException("Category not found");

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(category), TimeSpan.FromMinutes(20));

            return category;
        }

        public async Task Update(string id, UpdateCategoryRequest request)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null) throw new NotFoundException("Category not found");

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                category.Name = request.Name;
                category.Slug = _slugifyService.GenerateSlugify(request.Name);
            }
            category.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync("categories");
            await _cache.StringIncrementAsync("categories:version");
        }
    }
}
