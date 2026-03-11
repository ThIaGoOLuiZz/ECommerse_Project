using ECommerce.API.Models;
using ECommerce.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private IAuthRepository _authRepository;

        public AuthService(IConfiguration configuration, IAuthRepository authRepository)
        {
            _configuration = configuration;
            _authRepository = authRepository;
        }


        public string GenerateToken(string username, string userRole)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));
            int tokenExpirationMinutes = int.Parse(_configuration["JWT:TokenExpirationMinutes"]!);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:validIssuer"],
                audience: _configuration["JWT:validAudience"],
                expires: DateTime.UtcNow.AddMinutes(tokenExpirationMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> GenerateRefreshToken(int userId)
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:RefreshTokenExpirationMinutes"]!)),
                IsRevoked = false,
                UserId = userId
            };

            await _authRepository.SaveRefreshToken(refreshToken);

            return refreshToken.Token;
        }
    }
}
