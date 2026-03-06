using AutoMapper;
using ECommerce.API.Context;
using ECommerce.API.DTOs;
using ECommerce.API.DTOs.Mapping;
using ECommerce.API.Models;
using ECommerce.API.Repository;
using ECommerce.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDTOMappingProfile _mapping;
        private IUserRepository _userRepository;

        public UserController
        (
            IPasswordService passwordService,
            AppDbContext appDbContext,
            IUserDTOMappingProfile mapping,
            IUserRepository userRepository
        )
        {
            _mapping = mapping;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            if (users == null) 
                return NotFound(new { StatusCode = 404, Error = "No users found!" });
            var usersResponse = users.Select(x => _mapping.UserToUserResponse(x));

            return Ok(new { StatusCode = 200, Users = usersResponse });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null) 
                return NotFound(new { StatusCode = 404, Error = "User not found!" });
            var userResponse = _mapping.UserToUserResponse(user);

            return Ok(new { StatusCode = 200, User = userResponse });
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserRequestDTO userRequestDTO) 
        {
            
            var user = _mapping.UserRequestDTOToUser(userRequestDTO);
            var userCreated = _mapping.UserToUserResponse(await _userRepository.CreateUserAsync(user));

            return Created(string.Empty, new { StatusCode = 201, Id = userCreated.Id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (await _userRepository.GetUserById(id) is null) 
                return NotFound(new { StatusCode = 404, Error = "User not found!" });
            await _userRepository.DeleteUserAsync(id);

            return Ok(new { StatusCode = 200, DeletedId = id });
        }
    }
}
