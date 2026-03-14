using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    [Table("vouchers")]
    public class Voucher
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(30)]
        [Column("code")]
        public string Code { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [Column("discount_percent")]
        public int DiscountPercent { get; set; }
        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;
        [Column("creadted_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
