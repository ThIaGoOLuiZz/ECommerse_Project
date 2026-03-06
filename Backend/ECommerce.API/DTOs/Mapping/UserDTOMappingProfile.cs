using AutoMapper;
using ECommerce.API.Models;
using System.Runtime.InteropServices;

namespace ECommerce.API.DTOs.Mapping
{
    public class UserDTOMappingProfile : IUserDTOMappingProfile
    {
        public UserDTOMappingProfile(){ }

        public User UserRequestDTOToUser(UserRequestDTO userRequestDTO)
        {
            return new User
            {
                Name = userRequestDTO.Name,
                Mail = userRequestDTO.Mail,
                Phone = userRequestDTO.Phone,
                UserType = userRequestDTO.UserType,
                HashedPassword = null
            };
        }

        public UserResponseDTO UserToUserResponse(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Mail = user.Mail,
                Phone = user.Phone,
                UserType = user.UserType,
                CreatedAt = user.CreatedAt.AddHours(-3)
            };
        }
    }
}
