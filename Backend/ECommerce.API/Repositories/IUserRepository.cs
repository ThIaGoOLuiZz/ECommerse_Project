using ECommerce.API.Models;

namespace ECommerce.API.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> CreateUserAsync(User user);
        public Task DeleteUserAsync(int id);
        public Task<bool> EmailExist(string email);
    }
}
