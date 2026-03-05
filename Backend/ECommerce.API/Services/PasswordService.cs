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
            var configSection = _configuration.GetSection("BCrypt");
            string secretKey = configSection["secretKey"]!;
            int workFactor = int.Parse(configSection["workFactor"]!);

            password = ConcatPassword(password, secretKey);

            return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
        }

        public bool VerifyPassword(string password, string hashPassword)
        {
            throw new NotImplementedException();
        }

        public string ConcatPassword(string password, string secretKey)
        {
            return $"{password}{secretKey}";
        }
    }
}
