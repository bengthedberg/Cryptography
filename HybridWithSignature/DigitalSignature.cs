using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HybridWithSignature
{
    public class DigitalSignature
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

        public byte[] SignData(byte[] hashOfDataToSign)
        {
            using (var rsa = new RSACryptoServiceProvider(keyLength))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_privateKey);

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                return rsaFormatter.CreateSignature(hashOfDataToSign);
            }
        }

        public bool VerifySignature(byte[] hashOfDataToSign, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(keyLength))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_publicKey);

                var rsaFormatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                return rsaFormatter.VerifySignature(hashOfDataToSign, signature);
            }
        }
    }
}
