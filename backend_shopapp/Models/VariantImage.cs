using backend_shopapp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    [Table("variant_images")]
    public class VariantImage
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(36)]
        [Column("variant_id")]
        public string VariantId { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("image_url")]
        public string ImageUrl { get; set; }
        [Column("is_main")]
        public bool IsMain { get; set; } = false;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Variant Variant { get; set; }
    }
}
