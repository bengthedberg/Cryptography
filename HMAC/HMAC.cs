using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HMAC
{
    public class HMAC
    {
        private const int keySize = 32;

        public static byte[] GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var key = new byte[keySize];
                rng.GetBytes(key);

                return key;
            }
        }

        public static byte[] ComputeHMACSHA1(byte[] message, byte[] key)
        {
            using (var sha1 = new HMACSHA1(key))
            {
                return sha1.ComputeHash(message);
            }
        }

        public static byte[] ComputeHMACSHA256(byte[] message, byte[] key)
        {
            using (var sha256 = new HMACSHA256(key))
            {
                return sha256.ComputeHash(message);
            }
        }

        public static byte[] ComputeHMACSHA512(byte[] message, byte[] key)
        {
            using (var sha512 = new HMACSHA512(key))
            {
                return sha512.ComputeHash(message);
            }
        }

        public static byte[] ComputeHMACMD5(byte[] message, byte[] key)
        {
            using (var md5 = new HMACMD5(key))
            {
                return md5.ComputeHash(message);
            }
        }

    }
}
