using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs
{
    public class RefreshTokenRequestDTO
    {
        [Required]
        public required string RefreshToken { get; set; }
    }
}
