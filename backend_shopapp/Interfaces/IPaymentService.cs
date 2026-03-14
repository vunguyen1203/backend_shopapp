using backend_shopapp.Dtos.Payment;

namespace backend_shopapp.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreatePayment(CreatePaymentRequest request, HttpContext context, string userName);
        Task VnPayReturn(IQueryCollection collections);
    }
}
