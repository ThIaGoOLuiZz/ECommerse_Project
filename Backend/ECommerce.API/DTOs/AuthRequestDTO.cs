using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs
{
    public class AuthRequestDTO
    {
        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email!")]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
