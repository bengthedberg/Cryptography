using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    public class RSAWithCSPKey
    {
        private const int keySize = 2048; // 1024, 2048 or 4096
        const string containerName = "MyContainer";

        public void AssignKey()
        {
            // To specify a provider compatible with the RSA algorithm, pass a value of 1 to the dwTypeIn parameter.
            CspParameters cspParam = new CspParameters(dwTypeIn: 1);
            cspParam.KeyContainerName = containerName;
            cspParam.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParam.ProviderName = "Microsoft Strong Cryptographic Provider";

            var rsa = new RSACryptoServiceProvider(cspParam)
            {
                PersistKeyInCsp = true
            };
        }

        public void DeleteKey()
        {
            CspParameters cspParam = new CspParameters { KeyContainerName = containerName };
            var rsa = new RSACryptoServiceProvider(cspParam)
            {
                PersistKeyInCsp = false
            };
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherData;

            CspParameters cspParam = new CspParameters { KeyContainerName = containerName };

            using (var rsa = new RSACryptoServiceProvider(keySize, cspParam))
            {
                cipherData = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherData;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plainData;

            CspParameters cspParam = new CspParameters { KeyContainerName = containerName };

            using (var rsa = new RSACryptoServiceProvider(keySize, cspParam))
            {
                plainData = rsa.Decrypt(dataToDecrypt, false);
            }

            return plainData;
        }

    }
}
