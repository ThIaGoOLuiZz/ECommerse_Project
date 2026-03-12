using ECommerce.API.Context;
using ECommerce.API.Models;
using ECommerce.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private AppDbContext _dbContext;
        private IUserRepository _userRepository;
        public AuthRepository(AppDbContext appDbContext, IUserRepository userRepository)
        {
            _dbContext = appDbContext;
            _userRepository = userRepository;
        }

        public async Task<int?> GetUserIdByRefreshToken(string refreshToken)
        {
            return await _dbContext.RefreshTokens
                .Where(x => x.Token == refreshToken)
                .Select(x => (int?)x.UserId)
                .FirstOrDefaultAsync();
        }

        public async Task SaveRefreshToken(RefreshToken refreshToken)
        {
            await DeleteRefreshToken(refreshToken);

            _dbContext.RefreshTokens.Add(refreshToken);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken, int userId)
        {
            return await _dbContext.RefreshTokens
                .Where(x => x.Token == refreshToken 
                            && x.UserId == userId
                            && !x.IsRevoked 
                            && x.ExpiresAt > DateTime.UtcNow)
                .AnyAsync();
        }

        public async Task DeleteRefreshToken(RefreshToken refreshToken)
        {
            await _dbContext.RefreshTokens
                .Where(x => x.UserId == refreshToken.UserId)
                .ForEachAsync(x => _dbContext.Remove(x));
        }
    }
}
