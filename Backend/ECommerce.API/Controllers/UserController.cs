using AutoMapper;
using ECommerce.API.Context;
using ECommerce.API.DTOs;
using ECommerce.API.DTOs.Mapping;
using ECommerce.API.Models;
using ECommerce.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IPasswordService _passwordService;
        private AppDbContext _appDbContext;
        private IUserDTOMappingProfile _mapping;
        public UserController(IPasswordService passwordService, AppDbContext appDbContext, IUserDTOMappingProfile mapping)
        {
            _passwordService = passwordService;
            _appDbContext = appDbContext;
            _mapping = mapping;
        }

        [HttpPost]
        public ActionResult Teste([FromBody] UserRequestDTO userRequestDTO) {
            if (userRequestDTO is null)
            {
                return BadRequest();
            }

            User user = _mapping.ToUser(userRequestDTO);
            user.HashedPassword = _passwordService.HashGeneration(userRequestDTO.Password!);

            _appDbContext.Add(user);
            _appDbContext.SaveChanges();

            return Ok(user);
        }
    }
}
