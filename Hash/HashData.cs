using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hash
{
    public class HashData
    {
        public static byte[] ComputeHashSHA1(byte[] message)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(message);
            }
        }
        public static byte[] ComputeHashSHA256(byte[] message)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(message);
            }
        }

        public static byte[] ComputeHashSHA512(byte[] message)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(message);
            }
        }

        public static byte[] ComputeHashMD5(byte[] message)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(message);
            }
        }
    }
}
