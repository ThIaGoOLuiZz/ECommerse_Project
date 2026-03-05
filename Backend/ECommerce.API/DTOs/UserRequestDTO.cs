using ECommerce.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public UserTypeEnum UserType { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
