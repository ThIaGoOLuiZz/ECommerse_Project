using ECommerce.API.DTOs;
using ECommerce.API.Repository;
using ECommerce.API.Services;
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

        public AuthController(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult> Login([FromBody] AuthRequestDTO authRequestDTO)
        {
            var user = await _userRepository.GetUserByEmail(authRequestDTO.Email!);
            bool isPasswordValid = user is null ? false : _passwordService.VerifyPassword(authRequestDTO.Password!, user.HashedPassword!);

            if (!isPasswordValid)
            {
                return Unauthorized(new { StatusCode = 401, Error = "Invalid credentials" });
            }

            return Ok(new { StatusCode = 200, Id = user!.Id});
        }
    }
}
