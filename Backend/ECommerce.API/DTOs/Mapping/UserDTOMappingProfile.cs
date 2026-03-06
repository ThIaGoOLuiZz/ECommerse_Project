using AutoMapper;
using ECommerce.API.Models;
using ECommerce.API.Services;
using System.Runtime.InteropServices;

namespace ECommerce.API.DTOs.Mapping
{
    public class UserDTOMappingProfile : IUserDTOMappingProfile
    {
        private IPasswordService _passwordService;
        public UserDTOMappingProfile(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public User UserRequestDTOToUser(UserRequestDTO userRequestDTO)
        {
            return new User
            {
                Name = userRequestDTO.Name,
                Email = userRequestDTO.Email,
                Phone = userRequestDTO.Phone,
                UserType = userRequestDTO.UserType,
                HashedPassword = _passwordService.HashGeneration(userRequestDTO.Password!)
            };
        }

        public UserResponseDTO UserToUserResponse(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                UserType = user.UserType,
                CreatedAt = user.CreatedAt.AddHours(-3)
            };
        }
    }
}
