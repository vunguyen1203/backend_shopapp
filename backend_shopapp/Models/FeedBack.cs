using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    [Table("feedbacks")]
    public class FeedBack
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(36)]
        [Column("user_id")]
        public string UserId { get; set; }
        public string? ParentId { get; set; }
        [Required]
        [MaxLength(36)]
        [Column("product_id")]
        public string ProductId { get; set; }
        [MaxLength(255)]
        [Column("content")]
        public string? Content { get; set; }
        [Column("rating")]
        public int? Rating { get; set; } = 0;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
        public FeedBack? Parent { get; set; }
        public ICollection<FeedBack>? Replies { get; set; }
    }
}
