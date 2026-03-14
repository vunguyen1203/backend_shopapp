using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.User
{
    public class UpdateUserByAdminRequest
    {
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [MinLength(6)]
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool? IsBlocked { get; set; } = false;
    }
}
