using System;
using System.Text;

namespace TripleDES
{
    class Program
    {
        static void Main(string[] args)
        {
            var des = new TripleDESEncryption();
            // Create 3 keys (3 64 bit keys) 
            var key = des.GenerateRandomNumbers(24); // use des.GenerateRandomNumbers(16); for 2 64 bit keys
            // Create a initialization vector to prevent repetition of block chipers
            var iv = des.GenerateRandomNumbers(8);

            const string message = "String to encrypt";

            Console.WriteLine("Triple DES Encryption / Decryption Demonstartion");
            Console.WriteLine("------------------------------------------------");

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
