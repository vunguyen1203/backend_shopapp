using backend_shopapp.Dtos.Payment;

namespace backend_shopapp.Interfaces
{
    public interface IVnpayService
    {
        string CreatePaymentUrl(PaymentInformation model, HttpContext context);
        PaymentResponse PaymentExecute(IQueryCollection collections);
    }
}
