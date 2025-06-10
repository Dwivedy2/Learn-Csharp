namespace PasswordManager.Entities.Models
{
    public class User : BaseEntity
    {
        public string? Email { get; set; }
        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public ICollection<Site>? Sites { get; set; }
    }
}
