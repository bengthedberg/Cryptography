using System;
using System.Text;

namespace DES
{
    class Program
    {
        static void Main(string[] args)
        {
            var des = new DESEncryption();
            // Create a 56 bit key for the DES to use to encrypt and decrypt
            var key = des.GenerateRandomNumbers(8); 
            // Create a initialization vector to prevent repetition of block chipers
            var iv = des.GenerateRandomNumbers(8);

            const string message = "String to encrypt";
            
            Console.WriteLine("DES Encryption / Decryption Demonstartion");
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
