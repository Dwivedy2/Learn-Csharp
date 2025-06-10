namespace PasswordManager.Interfaces
{
    public interface IPasswordHasher
    {
        string GenerateHash(string password, string salt);
        string GenerateSalt();
    }
}
