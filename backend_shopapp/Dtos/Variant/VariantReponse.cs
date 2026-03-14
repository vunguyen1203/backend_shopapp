namespace backend_shopapp.Dtos.Variant
{
    public class VariantReponse
    {
        public string Id { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public string? AttributesOrther { get; set; }
        public List<string> Images { get; set; }
        public bool IsMain { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
