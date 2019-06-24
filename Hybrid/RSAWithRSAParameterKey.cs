using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hybrid
{
    public class RSAWithRSAParameterKey
    {
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;
        private const int keyLength = 2048;

        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(keyLength))
            {
                rsa.PersistKeyInCsp = false;
                _privateKey = rsa.ExportParameters(true);
                _publicKey = rsa.ExportParameters(false);
            }
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherData;

            using (var rsa = new RSACryptoServiceProvider(keyLength))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_publicKey);
                cipherData = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherData;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plainData;

            using (var rsa = new RSACryptoServiceProvider(keyLength))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_privateKey);
                plainData = rsa.Decrypt(dataToDecrypt, false);
            }

            return plainData;
        }

    }
}
