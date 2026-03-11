namespace ECommerce.API.Services
{
    public interface IAuthService
    {
        public string GenerateToken(string username, string userRole);
        public Task<string> GenerateRefreshToken(int userId);
    }
}
