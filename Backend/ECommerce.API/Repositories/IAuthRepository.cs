using ECommerce.API.Models;

namespace ECommerce.API.Repositories
{
    public interface IAuthRepository
    {
        public Task SaveRefreshToken(RefreshToken refreshToken);
        public Task<bool> ValidateRefreshToken(string refreshToken, int userId);
        public Task<int?> GetUserIdByRefreshToken(string refreshToken);
        public Task DeleteRefreshToken(RefreshToken refreshToken);
    }
}
