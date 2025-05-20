using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Entities.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string? Email { get; set; }
        public byte[]? Password { get; set; }
        public ICollection<Site> Sites { get; set; }
    }
}
