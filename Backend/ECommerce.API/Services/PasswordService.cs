using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IConfiguration _configuration;
        public PasswordService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string HashGeneration(string password)
        {
            int workFactor = int.Parse(GetBCryptSection()["workFactor"]!);

            password = ConcatPassword(password);

            return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
        }

        public bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(ConcatPassword(password), hashPassword);
        }

        public string ConcatPassword(string password)
        {
            string secretKey = GetBCryptSection()["secretKey"]!;
            return $"{password}{secretKey}";
        }
        private IConfiguration GetBCryptSection()
        {
            return _configuration.GetSection("BCrypt");
        }
    }
}
