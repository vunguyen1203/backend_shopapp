using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.User
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [MinLength(6)]
        public string? Password { get; set; }
    }
}
