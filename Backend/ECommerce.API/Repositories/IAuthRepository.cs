using ECommerce.API.Models;

namespace ECommerce.API.Repositories
{
    public interface IAuthRepository
    {
        public Task SaveRefreshToken(RefreshToken refreshToken);
    }
}
