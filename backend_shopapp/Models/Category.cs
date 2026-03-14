using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    [Table("categories")]
    public class Category
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
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
