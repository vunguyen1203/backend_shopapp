using backend_shopapp.Models;

namespace backend_shopapp.Interfaces
{
    public interface IJwtService
    {
        public string GenerateAccessToken(User user);
        public string GenerateRefreshToken();
    }
}
