using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PBKDF2
{
    public class PBKDF2
    {
        public const int saltSize = 32;
        public const int hashSize = 32;

        public static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[saltSize];
                rng.GetBytes(salt);

                return salt;
            }
        }

        public static byte[] HashPassword(byte[] password, byte[] salt, int iterations)
        {
            using (var sharfc2898 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return sharfc2898.GetBytes(hashSize);
            }
        }

    }
}
