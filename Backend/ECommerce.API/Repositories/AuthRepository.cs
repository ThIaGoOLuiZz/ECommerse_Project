using ECommerce.API.Context;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private AppDbContext _dbContext;
        public AuthRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }


        public async Task SaveRefreshToken(RefreshToken refreshToken)
        {
            await _dbContext.RefreshTokens.Where(x => x.UserId == refreshToken.UserId).ForEachAsync(x => _dbContext.Remove(x));
            
            _dbContext.RefreshTokens.Add(refreshToken);

            await _dbContext.SaveChangesAsync();
        }
    }
}
