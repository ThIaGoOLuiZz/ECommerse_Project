using ECommerce.API.Context;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(int id) 
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _appDbContext.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = _appDbContext.Users.First(x => x.Id == id);
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<bool> isMailExist(int id)
        {
            throw new NotImplementedException();
        }
    } 
}
