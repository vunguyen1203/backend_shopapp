using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Order
{
    public class ConfirmOrderRequest
    {
        [Required]
        public string PaymentMethod { get; set; }
    }
}
