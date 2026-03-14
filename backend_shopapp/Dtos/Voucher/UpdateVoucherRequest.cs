namespace backend_shopapp.Dtos.Voucher
{
    public class UpdateVoucherRequest
    {
        public string? Code { get; set; }
        public int? DiscountPercent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
