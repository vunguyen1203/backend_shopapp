using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    [Table("order_items")]
    public class OrderItem
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
        [Column("variant_id")]
        public string VariantId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [Column("quantity")]
        public int Quantity { get; set; } = 0;
        [Required]
        [Range(1, double.MaxValue)]
        [Column("price")]
        public double Price { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public Order Order { get; set; }
        public Variant Variant { get; set; }
    }
}
