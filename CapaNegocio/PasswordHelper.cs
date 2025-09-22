using System.Security.Cryptography;
using System.Linq;

namespace CapaNegocio
{
    public static class PasswordHelper
    {
        public static (byte[] hash, byte[] salt) CrearPasswordHash(string password)
        {
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt); // ✅ reemplaza RNGCryptoServiceProvider

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            return (hash, salt);
        }

        public static bool ValidarPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            return hash.SequenceEqual(storedHash); // retorna true o false dependiendo si coinciden
        }
    }
}
