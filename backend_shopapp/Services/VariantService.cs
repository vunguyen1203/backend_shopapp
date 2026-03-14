using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Variant;
using backend_shopapp.Exceptions;
using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace backend_shopapp.Services
{
    public class VariantService : IVariantService
    {
        private readonly AppDbContext _db;
        private readonly IVariantImageService _vImageService;
        private readonly IDatabase _cache;
        public VariantService(AppDbContext db,
            IVariantImageService vImageService,
            IConnectionMultiplexer connection)
        {
            _db = db;
            _vImageService = vImageService;
            _cache = connection.GetDatabase();
        }

        public async Task Create(string productId, CreateVariantRequest request)
        {
            var variantExist = await _db.Variants.FirstOrDefaultAsync(v => v.Sku == request.Sku);
            if (variantExist != null) throw new ConflictException ("Product variant is exist");

            if (request.IsMain)
            {
                bool mainVariantExist = await _db.Variants
                    .AnyAsync(v => v.ProductId == productId && v.IsMain);

                if (mainVariantExist) throw new ConflictException("This product already has a variant main");
            }

            var variant = new Variant
            {
                Sku = request.Sku,
                ProductId = productId,
                Price = request.Price,
                Stock = request.Stock,
                Color = request.Color,
                AttributesOrther = request.AttributesOrther,
                IsMain = request.IsMain
            };

            _db.Variants.Add(variant);
            await _db.SaveChangesAsync();

            if (request.Images != null)
                await _vImageService.UploadImages(variant.Id, request.Images);

            await _cache.StringIncrementAsync($"variants:{productId}:version");
        }

        public async Task Delete(string id)
        {
            var variant = await _db.Variants.FindAsync(id);
            if (variant == null) throw new NotFoundException("Variant not found");

            _db.Variants.Remove(variant);
            await _db.SaveChangesAsync();

            await _vImageService.DeleteImages(id);

            await _cache.StringIncrementAsync($"variants:{variant.ProductId}:version");
        }

        public async Task<List<VariantReponse>> GetAll(string productId, QueryParameters param)
        {
            bool productExist = await _db.Products.AnyAsync(p => p.Id == productId);
            if (!productExist) throw new NotFoundException("Product not found");

            string keyVersion = $"variants:{productId}:version";
            var version = await _cache.StringGetAsync(keyVersion);
            if (version.IsNullOrEmpty)
            {
                await _cache.StringIncrementAsync(keyVersion);
                version = 1;
            }

            string key = $"variants:{productId}:v{version}:{param.Search}:{param.Sort}:{param.Dir}:{param.Page}:{param.Size}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<List<VariantReponse>>(stored);

            var query = _db.Variants
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.Search))
                query = query.Where(u => u.Sku.Contains(param.Search));

            query = param.Dir == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, param.Sort))
                : query.OrderBy(e => EF.Property<object>(e, param.Sort));

            var variants = await query
                .Where(v => v.ProductId == productId)
                .Skip((param.Page - 1) * param.Size)
                .Take(param.Size)
                .Select(v => new VariantReponse
                {
                    Id = v.Id,
                    Sku = v.Sku,
                    Price = v.Price,
                    Stock = v.Stock,
                    Color = v.Color,
                    AttributesOrther = v.AttributesOrther,
                    Images = v.Images
                        .OrderByDescending(i => i.IsMain)
                        .Select(i => i.ImageUrl)
                        .ToList(),
                    IsMain = v.IsMain,
                    CreatedAt = v.CreatedAt,
                    UpdatedAt = v.UpdatedAt,
                }).ToListAsync();

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(variants), TimeSpan.FromMinutes(10));

            return variants;
        }

        public async Task Update(string id, UpdateVariantRequest request)
        {
            var variant = await _db.Variants.FindAsync(id);
            if (variant == null) throw new NotFoundException("Variant not found");

            if (variant.Sku == request.Sku)
                throw new ConflictException("Product variant is exist");

            if (request.IsMain == true && request.IsMain == variant.IsMain)
                throw new ConflictException("This product already has a variant main");

            if (!string.IsNullOrWhiteSpace(request.ProductId)) variant.ProductId = request.ProductId;
            if (!string.IsNullOrWhiteSpace(request.Sku)) variant.Sku = request.Sku;
            if (request.Price.HasValue) variant.Price = request.Price.Value;
            if (request.Stock.HasValue) variant.Stock = request.Stock.Value;
            if (!string.IsNullOrWhiteSpace(request.Color)) variant.Color = request.Color;
            if (!string.IsNullOrWhiteSpace(request.AttributesOrther)) variant.AttributesOrther = request.AttributesOrther;
            if (request.IsMain.HasValue) variant.IsMain = request.IsMain.Value;
            variant.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            if (request.Images != null) await _vImageService.UpDateImages(id, request.Images);

            await _cache.StringIncrementAsync($"variants:{variant.ProductId}:version");
        }
    }
}
