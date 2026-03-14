using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.User
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
