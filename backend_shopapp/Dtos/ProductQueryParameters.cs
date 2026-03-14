namespace backend_shopapp.Dtos
{
    public class ProductQueryParameters : QueryParameters
    {
        public string? Brand { get; set; }
        public string? Category { get; set; }
    }
}
