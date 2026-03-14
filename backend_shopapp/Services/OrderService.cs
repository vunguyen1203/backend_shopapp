using backend_shopapp.Dtos.Order;
using backend_shopapp.Exceptions;
using backend_shopapp.Models;
using backend_shopapp.Dtos;
using backend_shopapp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_shopapp.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;

        public OrderService(AppDbContext db)
        {
            _db = db;
        }

        public async Task CancellOrder(string id)
        {
            var order = await _db.Orders.FindAsync(id);
            if (order ==null) throw new NotFoundException("Order not found");

            if (order.Status != nameof(OrderStatus.pending))
                throw new BadRequestException("Order cannot be cancelled because its status is not pending");

            order.Status = nameof(OrderStatus.cancelled);
            order.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }

        public async Task ConfirmOrderSuccess(string orderId)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();
            
            try
            {
                var order = await _db.Orders
                    .Include(o => o.Payment)
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order == null)
                    throw new NotFoundException("Order not found");

                if (order.Status == nameof(OrderStatus.completed))
                    throw new ConflictException("Order already completed");

                if (order.Payment == null)
                    throw new NotFoundException("Payment not found");

                if (order.Payment.PaymentMethod == nameof(PaymentMethod.vnpay) &&
                    order.Payment.PaymentStatus == nameof(PaymentStatus.paid))
                {
                    throw new ConflictException("Already paid");
                }

                if (order.Payment.PaymentMethod == nameof(PaymentMethod.cod))
                {
                    order.Payment.PaymentStatus = nameof(PaymentStatus.paid);
                    order.Payment.PaidAt = DateTime.UtcNow;
                    order.Payment.UpdatedAt = DateTime.UtcNow;
                }

                var variantIds = order.OrderItems.Select(x => x.VariantId).ToList();

                var variants = await _db.Variants
                    .Where(v => variantIds.Contains(v.Id))
                    .ToDictionaryAsync(v => v.Id);

                foreach (var item in order.OrderItems)
                {
                    if (!variants.TryGetValue(item.VariantId, out var variant))
                        throw new NotFoundException($"Variant {item.VariantId} not found");

                    if (variant.Stock < item.Quantity)
                        throw new BadRequestException($"Not enough stock for variant {item.VariantId}");

                    variant.Stock -= item.Quantity;
                    variant.UpdatedAt = DateTime.UtcNow;
                }

                order.Status = nameof(OrderStatus.completed);
                order.UpdatedAt = DateTime.UtcNow;

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<string> Create(string userId, CreateOrderRequest request)
        {
            if (request.Items == null || !request.Items.Any())
                throw new NotFoundException("Items not found in request");

            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    UserId = userId,
                    OrderCode = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
                    Name = request.Name,
                    Address = request.Address,
                    Phone = request.Phone,
                    Status = nameof(OrderStatus.pending),
                    OrderItems = new List<OrderItem>()
                };

                double total = 0d;

                var variantIds = request.Items.Select(i => i.VariantId).ToList();

                var variants = await _db.Variants
                    .Where(v => variantIds.Contains(v.Id))
                    .Select(v => new
                    {
                        v.Id,
                        v.Price
                    })
                    .ToDictionaryAsync(v => v.Id);

                foreach (var item in request.Items)
                {
                    if (!variants.TryGetValue(item.VariantId, out var variant))
                        throw new NotFoundException($"Variant {item.VariantId} not found");

                    order.OrderItems.Add(new OrderItem
                    {
                        VariantId = item.VariantId,
                        Quantity = item.Quantity,
                        Price = variant.Price
                    });

                    total += variant.Price * item.Quantity;
                }

                if (!string.IsNullOrWhiteSpace(request.Voucher))
                {
                    var voucher = await _db.Vouchers
                        .FirstOrDefaultAsync(v => v.Code == request.Voucher);

                    if (voucher == null)
                        throw new NotFoundException("Voucher not found");

                    if (!voucher.IsActive || voucher.EndDate < DateTime.UtcNow)
                        throw new BadRequestException("Voucher expired or not active");

                    total -= total * (voucher.DiscountPercent / 100.0);
                }

                order.TotalAmount = total;

                _db.Orders.Add(order);

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return order.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<OrderResponse>> GetAll(OrderQueryParameters param, string userId)
        {
            var query = _db.Orders
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(userId))
                query = query.Where(o => o.UserId == userId);

            if (!string.IsNullOrWhiteSpace(param.Search))
                query = query.Where(o => o.OrderCode.Contains(param.Search));

            if (!string.IsNullOrWhiteSpace(param.Status)) 
                query = query.Where(o => o.Status.Contains(param.Status));

            query = param.Dir == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, param.Sort))
                : query.OrderBy(e => EF.Property<object>(e, param.Sort));

            var orders = await query
                .Skip((param.Page - 1) * param.Size)
                .Take(param.Size)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderCode = o.OrderCode,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    Name = o.Name,
                    Address = o.Address,
                    Phone = o.Phone,
                    PaymentMethod = o.Payment.PaymentMethod,
                    PaymentStatus = o.Payment.PaymentStatus,
                    Items = o.OrderItems.Select(i => new OrderItemResponse
                    {
                        Id = i.Id,
                        VariantId = i.VariantId,
                        ProductName = i.Variant.Product.Name,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList(),
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt,
                }).ToListAsync();

            return orders;
        }

        public async Task<OrderResponse> GetById(string id)
        {
            var order = await _db.Orders
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderCode = o.OrderCode,
                    TotalAmount = o.TotalAmount,
                    Name = o.Name,
                    Status = o.Status,
                    Address = o.Address,
                    Phone = o.Phone,
                    PaymentMethod = o.Payment.PaymentMethod,
                    PaymentStatus = o.Payment.PaymentStatus,
                    Items = o.OrderItems.Select(i => new OrderItemResponse
                    {
                        VariantId = i.VariantId,
                        Quantity = i.Quantity,
                        ProductName = i.Variant.Product.Name,
                        Price = i.Price
                    }).ToList(),
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt,
                }).FirstOrDefaultAsync();
                if (order == null) throw new NotFoundException("Order not found");

            return order;
        }

        public async Task SetShipping(string orderCode)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (order == null) throw new Exception("Order not found");

            switch (order.Status)
            {
                case nameof(OrderStatus.pending):
                    order.Status = nameof(OrderStatus.shipping);
                    order.UpdatedAt = DateTime.UtcNow;
                    break;

                case nameof(OrderStatus.shipping):
                    throw new BadRequestException("Order is already being shipped.");

                case nameof(OrderStatus.completed):
                    throw new BadRequestException("Order has already been completed.");

                case nameof(OrderStatus.cancelled):
                    throw new BadRequestException("Cancelled orders cannot be shipped.");

                case nameof(OrderStatus.refund):
                    throw new BadRequestException("Refunded orders cannot be shipped.");

                default:
                    throw new BadRequestException("Invalid order status.");
            }

            await _db.SaveChangesAsync();
        }

        public async Task UpdateInfo(string id, UpdateOrderRequest request)
        {
            var order = await _db.Orders.FindAsync(id);
            if (order == null) throw new Exception("Order not found");

            if (!string.IsNullOrWhiteSpace(request.Name)) order.Name = request.Name;

            if (order.Status == nameof(OrderStatus.pending))
            {
                if (!string.IsNullOrWhiteSpace(request.Address)) order.Address = request.Address;
                if (!string.IsNullOrWhiteSpace(request.Phone)) order.Phone = request.Phone;
            }
            else
            {
                throw new ConflictException("Order cannot be updated because its status is not pending");
            }

            if (!string.IsNullOrWhiteSpace(request.Status)) order.Status = request.Status;
            order.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
        }
    }
}
