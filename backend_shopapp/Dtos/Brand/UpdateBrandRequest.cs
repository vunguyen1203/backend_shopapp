namespace backend_shopapp.Dtos.Brand
{
    public class UpdateBrandRequest
    {
        public string? Name { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
