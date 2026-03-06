using ECommerce.API.Models;

namespace ECommerce.API.DTOs.Mapping
{
    public interface IUserDTOMappingProfile
    {
        public User UserRequestDTOToUser(UserRequestDTO userRequestDTO);
        public UserResponseDTO UserToUserResponse(User user);
    }
}
