using AutoMapper;
using ECommerce.API.Models;
using System.Runtime.InteropServices;

namespace ECommerce.API.DTOs.Mapping
{
    public class UserDTOMappingProfile : IUserDTOMappingProfile
    {
        public UserDTOMappingProfile(){ }

        public User ToUser(UserRequestDTO userRequestDTO)
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
    }
}
