using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Dtos.Order
{
    public class CreateOrderRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Voucher { get; set; }

        public List<CreateOrderItemRequest> Items { get; set; } = new();
    }
}
