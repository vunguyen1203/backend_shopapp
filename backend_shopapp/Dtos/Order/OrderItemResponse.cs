namespace backend_shopapp.Dtos.Order
{
    public class OrderItemResponse
    {
        public string Id { get; set; }
        public string VariantId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
