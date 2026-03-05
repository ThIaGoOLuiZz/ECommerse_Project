namespace ECommerce.API.Services
{
    public interface IPasswordService
    {
        public string HashGeneration(string password);
        public bool VerifyPassword(string password, string hashPassword);
    }
}
