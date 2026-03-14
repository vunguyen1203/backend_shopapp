using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.User
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
