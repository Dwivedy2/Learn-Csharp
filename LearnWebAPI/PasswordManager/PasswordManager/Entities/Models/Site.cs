namespace PasswordManager.Entities.Models
{
    public class Site : BaseEntity
    {
        public string? Domain { get; set; }
        public byte[]? Password { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
