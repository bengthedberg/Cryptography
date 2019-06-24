using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hybrid
{
    public class HybridEncryption
    {
        private readonly AESEncryption _aes = new AESEncryption();

        /// <summary>
        /// This is an example of what a sender would do to securely transmit data
        /// using a hybrid encryption solution, (combining symmetric (AES) encryption 
        /// with asymmetric encryption (RSA)). 
        /// </summary>
        /// <param name="data">Data to be encrypted</param>
        /// <param name="publicKey">The public key, used to encrypt the session key used to encrypt the data.</param>
        /// <returns>Encrypted Packet of data that can be securely transferred</returns>
        public EncryptedPacket EncryptData(byte[] data, RSAWithRSAParameterKey publicKey)
        {
            var encryptedPacket = new EncryptedPacket();

            // Generate our unique 256 bits session key
            var sessionKey = _aes.GenerateRandomNumbers(32);

            // Generate the 128 bit Initialization Vector
            encryptedPacket.Iv = _aes.GenerateRandomNumbers(16);

            // Encrypt data using AES (symmetric encryption) session key and IV
            encryptedPacket.EncryptedData = _aes.Encrypt(data, sessionKey, encryptedPacket.Iv);

            // Encrypt the session key with the public RSA key
            encryptedPacket.EncryptedSessionKey = publicKey.EncryptData(sessionKey);

            // Generate a HMAC using the unique session key
            using (var hmac = new HMACSHA256(sessionKey))
            {
                encryptedPacket.Hmac = hmac.ComputeHash(encryptedPacket.EncryptedData);
            }

            return encryptedPacket;
        }

        public byte[] DecryptData(EncryptedPacket encryptedPacket, RSAWithRSAParameterKey privateKey)
        {
            // Decrypt the unique 256 bits AES session key
            var sessionKey = privateKey.DecryptData(encryptedPacket.EncryptedSessionKey);

            // Validate the encrypted data is accurate
            using (var hmac = new HMACSHA256(sessionKey))
            {
                var hmacToCheck = hmac.ComputeHash(encryptedPacket.EncryptedData);
                if (!CompareBytes(encryptedPacket.Hmac, hmacToCheck))
                {
                    throw new CryptographicException("HMAC invalid, data is corrupted.");
                }
            }

           // Decrypt the data
            var data = _aes.Decrypt(encryptedPacket.EncryptedData, sessionKey, encryptedPacket.Iv);

            return data;
        }

        /// <summary>
        /// returns true if byte arrays are identical.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        private static bool CompareBytes(byte[] array1, byte[] array2)
        {
            var result = array1.Length == array2.Length;

            for (int i = 0; i < array1.Length && i < array2.Length; i++)
            {
                result &= array1[i] == array2[i];
            }

            return result;
        }
    }
}
