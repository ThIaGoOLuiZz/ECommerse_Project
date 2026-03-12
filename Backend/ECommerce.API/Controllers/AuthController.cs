using ECommerce.API.DTOs;
using ECommerce.API.Models;
using ECommerce.API.Repositories;
using ECommerce.API.Repository;
using ECommerce.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IPasswordService _passwordService;
        private IAuthService _authService;
        private IAuthRepository _authRepository;

        public AuthController(IUserRepository userRepository, IPasswordService passwordService, IAuthService authService, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _authService = authService;
            _authRepository = authRepository;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Login([FromBody] AuthRequestDTO authRequestDTO)
        {
            var user = await _userRepository.GetUserByEmail(authRequestDTO.Email!);
            bool isPasswordValid = user is null ? false : _passwordService.VerifyPassword(authRequestDTO.Password!, user.HashedPassword!);

            if (!isPasswordValid)
            {
                return Unauthorized(new { StatusCode = 401, Error = "Invalid credentials" });
            }

            await _authRepository.DeleteRefreshToken(user!.Id);

            var tokenModel = new TokenModel
            {
                AccessToken = _authService.GenerateToken(user!.Name!, user.UserType.ToString()),
                RefreshToken = await _authService.GenerateRefreshToken(user.Id)
            };

            return Ok(new { StatusCode = 200, Id = user!.Id, accessToken = tokenModel.AccessToken, refreshToken = tokenModel.RefreshToken });
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshAccessToken(RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            int? userId = await _authRepository.GetUserIdByRefreshToken(refreshTokenRequestDTO.RefreshToken!);
            if (userId is null)
                return Unauthorized(new { StatusCode = 401, Message = "Invalid Refresh Token!"});

            var user = await _userRepository.GetUserById(userId.Value);
            if (user is null)
                return Unauthorized(new { StatusCode = 401, Message = "Invalid Refresh Token!" });

            if (!await _authRepository.ValidateRefreshToken(refreshTokenRequestDTO.RefreshToken, user.Id))
                return Unauthorized(new { StatusCode = 401, Message = "Invalid Refresh Token!" });
            
            await _authRepository.DeleteRefreshToken(user.Id);

            var tokenModel = new TokenModel
            {
                AccessToken = _authService.GenerateToken(user.Name!, user.UserType.ToString()),
                RefreshToken = await _authService.GenerateRefreshToken(user.Id)
            };

            return Ok(new { StatusCode = 200, Id = user.Id, accessToken = tokenModel.AccessToken, refreshToken = tokenModel.RefreshToken });
        }
    }
}
