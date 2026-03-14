using backend_shopapp.Exceptions;
using backend_shopapp.Models;
using backend_shopapp.Dtos.Payment;
using backend_shopapp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_shopapp.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _db;
        private readonly IVnpayService _vnPayService;

        public PaymentService(AppDbContext db, IVnpayService vnPayService)
        {
            _db = db;
            _vnPayService = vnPayService;
        }

        public async Task<string> CreatePayment(CreatePaymentRequest request, HttpContext context, string userName)
        {
            var order = await _db.Orders.FindAsync(request.OrderId);
            if (order == null) throw new NotFoundException("Order not found");

            bool paymentExist = await _db.Payments
                .AnyAsync(p => p.OrderId == request.OrderId && p.PaymentStatus == nameof(PaymentStatus.paid));
            if (paymentExist) throw new ConflictException("Order has been paid");

            if (request.PaymentMethod == nameof(PaymentMethod.cod))
            {
                _db.Payments.Add(new Payment
                {
                    OrderId = order.Id,
                    PaymentMethod = nameof(PaymentMethod.cod),
                    PaymentStatus = nameof(PaymentStatus.unpaid),
                });
                await _db.SaveChangesAsync();

                return "COD payment created";
            }

            if (request.PaymentMethod == nameof(PaymentMethod.vnpay))
            {
                var paymentInfo = new PaymentInformation
                {
                    OrderType = "other",
                    Amount = order.TotalAmount,
                    Name = userName,
                    OrderCode = order.OrderCode,
                    OrderId = order.Id,
                };
                return _vnPayService.CreatePaymentUrl(paymentInfo, context);
            }

            throw new BadRequestException("Invalid payment method");
        }

        public async Task VnPayReturn(IQueryCollection collections)
        {
            var response = _vnPayService.PaymentExecute(collections);

            if (!response.Success) throw new BadRequestException("Payment verify failed");

            if (response.VnPayResponseCode != "00") throw new BadRequestException("Payment cancelled or failed");

            _db.Payments.Add(new Payment
            {
                OrderId = response.OrderId,
                PaymentMethod = nameof(PaymentMethod.vnpay),
                PaymentStatus = nameof(PaymentStatus.paid),
                PaidAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();
        }
    }
}
