using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HashPassword
{
    public class Hash
    {
        private const int saltSize = 32;

        public static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[saltSize];
                rng.GetBytes(salt);

                return salt;
            }
        }

        public static byte[] Combine(byte[] password, byte[] salt)
        {
            byte[] saltedPassword = new byte[password.Length + salt.Length];

            Buffer.BlockCopy(password, 0, saltedPassword, 0, password.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, password.Length, salt.Length);

            return saltedPassword;
        }

        public static byte[] HashPasswordWithSalt(byte[] password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Combine(password, salt));
            }
        }
    }
}
