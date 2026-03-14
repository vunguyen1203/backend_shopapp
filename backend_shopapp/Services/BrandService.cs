using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Brand;
using backend_shopapp.Exceptions;
using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace backend_shopapp.Services
{
    public class BrandService : IService<CreateBrandRequest, UpdateBrandRequest, BrandResponse>
    {
        private readonly AppDbContext _db;
        private readonly IImageService _imageService;
        private readonly ISlugifyService _slugifyServie;
        private readonly IDatabase _cache;

        public BrandService(AppDbContext db,
            IImageService imageService,
            ISlugifyService slugifyService,
            IConnectionMultiplexer connection)
        {
            _db = db;
            _imageService = imageService;
            _slugifyServie = slugifyService;
            _cache = connection.GetDatabase();
        }

        public async Task Create(CreateBrandRequest request)
        {
            bool brandExist = await _db.Brands.AnyAsync(b => b.Name == request.Name);
            if (brandExist) throw new ConflictException("Brand is exist");

            var brand = new Brand
            {
                Name = request.Name,
                Slug = _slugifyServie.GenerateSlugify(request.Name)
            };
            if (request.Logo != null)
                brand.Logo = await _imageService.UploadImage(request.Logo, "brands");

            _db.Brands.Add(brand);
            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync("brands:version");
        }

        public async Task Delete(string id)
        {
            var brand = await _db.Brands.FindAsync(id);
            if (brand == null) throw new NotFoundException("Brand not found");

            if (!string.IsNullOrWhiteSpace(brand.Logo)) await _imageService.DeleteImage(brand.Logo);

            _db.Brands.Remove(brand);
            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"brand:{id}");
            await _cache.StringIncrementAsync("brands:version");
        }

        public async Task<List<BrandResponse>> GetAll(QueryParameters param)
        {
            string keyVersion = "brands:version";
            var version = await _cache.StringGetAsync(keyVersion);
            if (version.IsNullOrEmpty)
            {
                await _cache.StringIncrementAsync(keyVersion);
                version = 1;
            }

            string key = $"brands:v{version}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<List<BrandResponse>>(stored);

            var brands = await _db.Brands.Select(b => new BrandResponse 
            {
                Id = b.Id,
                Name = b.Name,
                Slug = b.Slug,
                Logo = b.Logo,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt
            }).ToListAsync();

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(brands), TimeSpan.FromMinutes(10));

            return brands;
        }

        public async Task<BrandResponse?> GetById(string id)
        {   
            string key = $"brand:{id}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<BrandResponse>(stored);

            var brand = await _db.Brands
                .Where(b => b.Id == id)
                .Select(b => new BrandResponse
                {
                    Id = b.Id,
                    Name = b.Name,
                    Slug = b.Slug,
                    Logo = b.Logo,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                }).FirstOrDefaultAsync();
            if (brand == null) throw new NotFoundException("Brand not found");

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(brand), TimeSpan.FromMinutes(20));

            return brand;
        }

        public async Task Update(string id, UpdateBrandRequest request)
        {
            var brand = await _db.Brands.FindAsync(id);
            if (brand == null) throw new NotFoundException("Brand not found");

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                brand.Name = request.Name;
                brand.Slug = _slugifyServie.GenerateSlugify(request.Name);
            }
            if (request.Logo != null)
                brand.Logo = await _imageService.UpdateImage(request.Logo, brand.Logo, "brands");
            brand.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"brand:{id}");
            await _cache.StringIncrementAsync("brands:version");
        }
    }
}
