using backend_shopapp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(150)]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        [Column("slug")]
        public string Slug { get; set; }
        [MaxLength(255)]
        [Column("description")]
        public string? Description { get; set; }
        [Required]
        [MaxLength(36)]
        [Column("category_id")]
        public string? CategoryId { get; set; }
        [Required]
        [MaxLength(36)]
        [Column("brand_id")]
        public string? BrandId { get; set; }
        [Required]
        [Column("view")]
        public int View { get; set; } = 0;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Variant> Variants { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }
    }
}
