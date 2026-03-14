using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Voucher
{
    public class CreateVoucherRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public int DiscountPercent { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
