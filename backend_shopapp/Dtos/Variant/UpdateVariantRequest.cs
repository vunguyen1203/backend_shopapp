namespace backend_shopapp.Dtos.Variant
{
    public class UpdateVariantRequest
    {
        public string? ProductId { get; set; }
        public string? Sku { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public string? Color { get; set; }
        public string? AttributesOrther { get; set; }
        public bool? IsMain { get; set; }
        public List<IFormFile>? Images { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
