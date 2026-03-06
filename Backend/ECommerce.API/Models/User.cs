using ECommerce.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string? Mail { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression("^[1-9]{2}9[1-9][0-9]{7}$", ErrorMessage = "Telefone inválido!")]
        public string? Phone { get; set; }
        [Required]
        public UserTypeEnum UserType { get; set; }
        [Required]
        public string? HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
