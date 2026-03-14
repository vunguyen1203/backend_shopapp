using backend_shopapp.Dtos.Variant;

namespace backend_shopapp.Dtos.Product
{
    public class ProductResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public Double? Rating { get; set; }
        public int? View {  get; set; }
        public VariantReponse? Variant { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
