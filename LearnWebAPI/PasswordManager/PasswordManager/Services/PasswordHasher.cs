using PasswordManager.Constants;
using PasswordManager.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string password, string salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password),
                            Encoding.UTF8.GetBytes(salt),
                            PasswordHash.ITERATIONS,
                            PasswordHash.ALGORITHM, 
                            PasswordHash.KEY_SIZE);

            var hashedStr = Convert.ToBase64String(hash);

            return hashedStr;
        }

        public string GenerateSalt()
        {
            var rng = RandomNumberGenerator.Create();

            byte[] salt = new byte[PasswordHash.KEY_SIZE];

            rng.GetBytes(salt);

            string cryptSalt = Convert.ToBase64String(salt);

            return cryptSalt;
        }
    }
}
