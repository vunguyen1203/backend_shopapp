using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Variant
{
    public class CreateVariantRequest
    {
        [Required]
        public string Sku { get; set; }
        [Required]
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? Color { get; set; }
        public string? AttributesOrther { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required]
        public List<IFormFile>? Images { get; set; } = new List<IFormFile>();
    }
}
