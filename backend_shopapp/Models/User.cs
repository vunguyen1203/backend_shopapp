using backend_shopapp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_shopapp.Models
{
    public enum Roles
    {
        admin,
        mod,
        user
    }
    [Table("users")]
    public class User
    {
        [Key]
        [MaxLength(36)]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(150)]
        [Column ("name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("password")]
        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("role")]
        public string Role { get; set; } = nameof(Roles.user); //admin, mod, user
        [Required]
        [Column("is_blocked")]
        public bool IsBlocked { get; set; } = false;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }
    }
}
