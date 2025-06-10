using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Entities.DTO
{
    public class UserDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
