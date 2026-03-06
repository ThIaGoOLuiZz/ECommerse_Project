using ECommerce.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
