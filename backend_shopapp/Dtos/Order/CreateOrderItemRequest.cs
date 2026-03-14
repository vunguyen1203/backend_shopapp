using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Order
{
    public class CreateOrderItemRequest
    {
        [Required]
        public string VariantId { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;
    }
}
