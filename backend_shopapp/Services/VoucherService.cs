using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Voucher;
using backend_shopapp.Exceptions;
using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace backend_shopapp.Services
{
    public class VoucherService : IService<CreateVoucherRequest, UpdateVoucherRequest, VoucherResponse>
    {
        private readonly AppDbContext _db;
        private readonly IDatabase _cache;

        public VoucherService(AppDbContext db, IConnectionMultiplexer connection)
        {
            _db = db;
            _cache = connection.GetDatabase();
        }
        public async Task Create(CreateVoucherRequest request)
        {
            bool voucherExist = await _db.Vouchers.AnyAsync(v => v.Code == request.Code);
            if (voucherExist) throw new ConflictException("Voucher is exist");

            _db.Vouchers.Add(new Voucher
            {
                Code = request.Code,
                DiscountPercent = request.DiscountPercent,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = request.IsActive.Value
            });
            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync("vouchers:version");
        }

        public async Task Delete(string id)
        {
            var voucher = await _db.Vouchers.FindAsync(id);
            if (voucher == null) throw new NotFoundException("Voucher not found");

            _db.Vouchers.Remove(voucher);
            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync("vouchers:version");
        }

        public async Task<List<VoucherResponse>> GetAll(QueryParameters param)
        {
            string keyVersion = "vouchers:version";
            var version = await _cache.StringGetAsync(keyVersion);
            if (version.IsNullOrEmpty)
            {
                await _cache.StringIncrementAsync(keyVersion);
                version = 1;
            }

            string key = $"vouchers:v{version}:{param.Search}:{param.Sort}:{param.Dir}:{param.Page}:{param.Size}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<List<VoucherResponse>>(stored);

            var query = _db.Vouchers
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.Search))
                query = query.Where(p => p.Code.Contains(param.Search));

            query = param.Dir == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, param.Sort))
                : query.OrderBy(e => EF.Property<object>(e, param.Sort));

            var vouchers = await query
                .Skip((param.Page - 1) * param.Size)
                .Take(param.Size)
                .Select(v => new VoucherResponse
                {
                    Id = v.Id,
                    Code = v.Code,
                    DiscountPercent = v.DiscountPercent,
                    StartDate = v.StartDate,
                    EndDate = v.EndDate,
                    IsActive = v.IsActive,
                    CreatedAt = v.CreatedAt,
                    UpdatedAt = v.UpdatedAt,
                }).ToListAsync();

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(vouchers), TimeSpan.FromMinutes(10));

            return vouchers;
        }

        public async Task<VoucherResponse> GetById(string id)
        {
            string key = $"voucher:{id}";
            var stored = await _cache.StringGetAsync(key);
            if (!stored.IsNullOrEmpty)
                return JsonSerializer.Deserialize<VoucherResponse>(stored);

            var voucher = await _db.Vouchers
                .Where(v => v.Id == id)
                .Select(v => new VoucherResponse
                {
                    Id = v.Id,
                    Code = v.Code,
                    DiscountPercent = v.DiscountPercent,
                    StartDate = v.StartDate,
                    EndDate = v.EndDate,
                    IsActive = v.IsActive,
                    CreatedAt = v.CreatedAt,
                    UpdatedAt = v.UpdatedAt,
                }).FirstOrDefaultAsync();
            if (voucher == null) throw new NotFoundException("Voucher not found");

            await _cache.StringSetAsync(key, JsonSerializer.Serialize(voucher), TimeSpan.FromMinutes(20));

            return voucher;
        }

        public async Task Update(string id, UpdateVoucherRequest request)
        {
            var voucher = await _db.Vouchers.FindAsync(id);
            if (voucher == null) throw new NotFoundException("Voucher not found");

            if (!string.IsNullOrWhiteSpace(request.Code)) voucher.Code = request.Code;
            if (request.DiscountPercent.HasValue) voucher.DiscountPercent = request.DiscountPercent.Value;
            if (request.StartDate != null) voucher.StartDate = request.StartDate.Value;
            if (request.EndDate != null) voucher.EndDate = request.EndDate.Value;
            if (request.IsActive.HasValue) voucher.IsActive = request.IsActive.Value;
            voucher.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            await _cache.StringIncrementAsync("vouchers:version");
        }
    }
}
