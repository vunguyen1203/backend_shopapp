using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

enum PaymentMethod
{
    cod,
    vnpay
}

enum PaymentStatus
{
    unpaid,
    paid
}

namespace backend_shopapp.Models
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(36)]
        [Column("order_id")]
        public string OrderId { get; set; }
        [Required]
        [MaxLength(36)]
        [Column("payment_method")]
        public string PaymentMethod { get; set; } //cod, vnpay
        [Required]
        [MaxLength(36)]
        [Column("payment_status")]
        public string PaymentStatus { get; set; } //unpaid, paid
        [Column("pai_at")]
        public DateTime? PaidAt { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        public Order Order { get; set; }
    }
}
