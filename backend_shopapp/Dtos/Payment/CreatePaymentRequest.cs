using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Payment
{
    public class CreatePaymentRequest
    {
        [Required]
        public string OrderId { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
    }
}
