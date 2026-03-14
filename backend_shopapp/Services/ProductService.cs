using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Product;
using backend_shopapp.Dtos.Variant;
using backend_shopapp.Exceptions;
using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace backend_shopapp.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;
        private readonly ISlugifyService _slugifyService;
        private readonly IDatabase _cache;

        public ProductService(AppDbContext db,
            ISlugifyService slugifyService,
            IConnectionMultiplexer connection)
        {
            _db = db;
            _slugifyService = slugifyService;
            _cache = connection.GetDatabase();
        }
        public async Task<string> Create(CreateProductRequest request)
        {
            bool productExist = await _db.Products.AnyAsync(p => p.Name == request.Name);
            if (productExist) throw new ConflictException("Product is exist");

            var product = new Product
            {
                Name = request.Name,
                Slug = _slugifyService.GenerateSlugify(request.Name),
                Description = request.Description,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync("products:version");

            return product.Id;
        }

        public async Task Delete(string id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) throw new NotFoundException("Product not found");

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"product:{id}");
            await _cache.StringIncrementAsync("products:version");
        }

        public async Task<List<ProductResponse>> GetAll(ProductQueryParameters param)
        {
            string keyVersion = "products:version";
            var version = await _cache.StringGetAsync(keyVersion);
            if (version.IsNullOrEmpty)
            {
                await _cache.StringIncrementAsync(keyVersion);
                version = 1;
            }

            string key = $"products:v{version}:{param.Search}:{param.Brand}:{param.Category}:{param.Sort}:{param.Dir}:{param.Page}:{param.Size}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<List<ProductResponse>>(stored);

            var query = _db.Products
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.Search))
                query = query.Where(p => p.Name.Contains(param.Search));

            if (!string.IsNullOrWhiteSpace(param.Brand))
                query = query.Where(p => p.Brand.Name.Contains(param.Brand));

            if (!string.IsNullOrWhiteSpace(param.Category))
                query = query.Where(p => p.Category.Name.Contains(param.Category));

            if (param.Sort == "Price" || param.Sort == "price" )
            {
                query = param.Dir == "desc"
                    ? query.OrderByDescending(p => p.Variants.Min(v => v.Price))
                    : query.OrderBy(p => p.Variants.Min(v => v.Price));
            }
            else
            {
                query = param.Dir == "desc"
                    ? query.OrderByDescending(e => EF.Property<object>(e, param.Sort))
                    : query.OrderBy(e => EF.Property<object>(e, param.Sort));
            }

            var products = await query
                .Skip((param.Page - 1) * param.Size)
                .Take(param.Size)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Slug = p.Slug,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Category = p.Category.Name,
                    Brand = p.Brand.Name,
                    Rating = p.FeedBacks.Any() ? p.FeedBacks.Average(f => f.Rating) : 0,
                    View = p.View,
                    Variant = p.Variants
                    .Where(v => v.IsMain)
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
                        UpdatedAt = v.UpdatedAt
                    })
                    .FirstOrDefault()
                }).ToListAsync();

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(products), TimeSpan.FromMinutes(10));

            return products;
        }

        public async Task<ProductResponse?> GetById(string id)
        {
            string keyView = $"product:view:{id}";
            await _cache.StringIncrementAsync(keyView);
            await _cache.KeyExpireAsync(keyView, TimeSpan.FromHours(1));

            string key = $"product:{id}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<ProductResponse>(stored);

            var product = await _db.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Slug = p.Slug,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Category = p.Category.Name,
                    Brand = p.Brand.Name,
                    Rating = p.FeedBacks.Any() ? p.FeedBacks.Average(f => f.Rating) : 0,
                    View = p.View,
                    Variant = p.Variants
                    .Where(v => v.IsMain)
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
                        UpdatedAt = v.UpdatedAt
                    })
                    .FirstOrDefault()
                }).FirstOrDefaultAsync();
            if(product == null) throw new NotFoundException("Product not found");

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(product), TimeSpan.FromMinutes(20));

            return product;
        }

        public async Task Update(string id, UpdateProductRequest request)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) throw new NotFoundException("Product not found");

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                product.Name = request.Name;
                product.Slug = _slugifyService.GenerateSlugify(request.Name);
            }
            if (!string.IsNullOrWhiteSpace(request.Description)) product.Description = request.Description;
            if (!string.IsNullOrWhiteSpace(request.CategoryId)) product.CategoryId = request.CategoryId;
            if (!string.IsNullOrWhiteSpace(request.BrandId)) product.BrandId = request.BrandId;
            product.UpdatedAt = DateTime.UtcNow; 

            await _db.SaveChangesAsync();

            await _cache.KeyDeleteAsync($"product:{id}");
            await _cache.StringIncrementAsync("products:version");
        }
    }
}
