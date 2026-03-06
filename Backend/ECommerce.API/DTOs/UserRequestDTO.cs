using ECommerce.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email!")]
        public string? Email { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression("^[1-9]{2}9[1-9][0-9]{7}$", ErrorMessage = "Invalid phone number!")]
        public string? Phone { get; set; }
        [Required]
        public UserTypeEnum UserType { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
