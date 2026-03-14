using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Order
{
    public class UpdateOrderRequest
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
    }
}
