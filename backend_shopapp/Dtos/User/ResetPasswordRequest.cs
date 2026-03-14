using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.User
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}
