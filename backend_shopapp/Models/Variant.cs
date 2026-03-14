using backend_shopapp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    [Table("variants")]
    public class Variant
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(36)]
        [Column("product_id")]
        public string ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("sku")]
        public string Sku { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        [Column("price")]
        public double Price { get; set; }
        [Required]
        [Column("stock")]
        public int Stock { get; set; } = 0;
        [MaxLength(50)]
        [Column("color")]
        public string Color { get; set; }
        [Column("attributes_orther")]
        public string? AttributesOrther { get; set; }
        [Column("is_main")]
        public bool IsMain { get; set; } = false;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public Product Product { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<VariantImage> Images { get; set; }
    }
}
