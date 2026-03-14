namespace backend_shopapp.Dtos.Order
{
    public class OrderResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string OrderCode { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderItemResponse> Items { get; set; }
    }
}
