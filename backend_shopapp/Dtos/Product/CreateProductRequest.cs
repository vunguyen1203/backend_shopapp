using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Product
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string BrandId { get; set; }
    }
}
