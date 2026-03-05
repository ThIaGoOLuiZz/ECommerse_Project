using ECommerce.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string? Name { get; set; }
        [Required]
        [StringLength(300)]
        public string? Mail { get; set; }
        [Required]
        [StringLength(300)]
        public int Phone { get; set; }
        [Required]
        public UserTypeEnum UserType { get; set; }
        [Required]
        public string? HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
