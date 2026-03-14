namespace backend_shopapp.Dtos.Payment
{
    public class PaymentInformation
    {
        public string OrderType { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public string OrderCode { get; set; }
        public string OrderId { get; set; }
    }
}
