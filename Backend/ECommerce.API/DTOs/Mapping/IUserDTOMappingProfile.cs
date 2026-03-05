using ECommerce.API.Models;

namespace ECommerce.API.DTOs.Mapping
{
    public interface IUserDTOMappingProfile
    {
        public User ToUser(UserRequestDTO userRequestDTO);
    }
}
