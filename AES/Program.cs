using System;
using System.Text;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            var des = new AESEncryption();
            // Create a 256 bit key for the AES to use to encrypt and decrypt
            var key = des.GenerateRandomNumbers(32);
            // Create a initialization vector to prevent repetition of block chipers
            var iv = des.GenerateRandomNumbers(16);

            const string message = "String to encrypt";

            Console.WriteLine("AES Encryption / Decryption Demonstartion");
            Console.WriteLine("-----------------------------------------");

            var encryptedMessage = des.Encrypt(Encoding.UTF8.GetBytes(message), key, iv);
            var decryptedMessage = des.Decrypt(encryptedMessage, key, iv);

            Console.WriteLine();
            Console.WriteLine($" original message  : {message}");
            Console.WriteLine($" encrypted message : {Convert.ToBase64String(encryptedMessage)}");
            Console.WriteLine($" decrypted message : {Encoding.UTF8.GetString(decryptedMessage)}");

            Console.WriteLine();
        }
    }
}
