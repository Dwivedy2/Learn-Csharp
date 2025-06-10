using System.Security.Cryptography;

namespace PasswordManager.Constants
{
    public static class PasswordHash
    {
        public static readonly int KEY_SIZE = 64;
        public static readonly int ITERATIONS = 350000;
        public static readonly HashAlgorithmName ALGORITHM = HashAlgorithmName.SHA256;
    }
}
