namespace backend_shopapp.Dtos.Category
{
    public class CategoryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
