namespace backend_shopapp.Dtos.Product
{
    public class UpdateProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public string? BrandId { get; set; }
    }
}
