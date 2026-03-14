using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    enum OrderStatus
    {
        pending,
        completed,
        refund, 
        shipping, 
        cancelled
    }
    
    [Table("orders")]
    public class Order
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(36)]
        [Column("user_id")]
        public string UserId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("order_code")]
        public string OrderCode { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        [Column("total_amount")]
        public double TotalAmount { get; set; }
        [Required]
        [MaxLength(150)]
        [Column("status")]
        public string Status { get; set; } = nameof(OrderStatus.pending); //pending, completed, refund, shipping, cancelled
        [Required]
        [MaxLength(150)]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        [Column("address")]
        public string Address { get; set; }
        [Required]
        [MaxLength(150)]
        [Column("phone")]
        public string Phone { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
    }
}
