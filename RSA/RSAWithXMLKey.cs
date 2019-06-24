using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    public class RSAWithXMLKey
    {

        private const int keySize = 2048; // 1024, 2048 or 4096

        public void AssignKey(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(publicKeyPath))                
                    File.Delete(publicKeyPath);
                if (File.Exists(privateKeyPath))
                    File.Delete(privateKeyPath);

                var publicKeyPathDir = Path.GetDirectoryName(publicKeyPath);
                var privateKeyPathDir = Path.GetDirectoryName(privateKeyPath);

                if (!Directory.Exists(publicKeyPathDir))
                    Directory.CreateDirectory(publicKeyPathDir);
                if (!Directory.Exists(privateKeyPathDir))
                    Directory.CreateDirectory(privateKeyPathDir);

                File.WriteAllText(publicKeyPath, rsa.ToXMLString(false));
                File.WriteAllText(privateKeyPath, rsa.ToXMLString(true));
            }
        }

        public byte[] EncryptData(string publicKeyPath, byte[] dataToEncrypt)
        {
            byte[] cipherData;

            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXMLString(File.ReadAllText(publicKeyPath));
                cipherData = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherData;
        }

        public byte[] DecryptData(string privateKeyPath, byte[] dataToDecrypt)
        {
            byte[] plainData;

            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXMLString(File.ReadAllText(privateKeyPath));
                plainData = rsa.Decrypt(dataToDecrypt, false);
            }

            return plainData;
        }

    }
}
