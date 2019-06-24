using System;
using System.Text;

namespace HMAC
{
    class Program
    {
        static void Main(string[] args)
        {
            const string originalMessage = "This is a message";
            const string modifiedMessage = "Th!s is a message";

            Console.WriteLine("Hash Message Authenticate Code (HMAC) Data Demonstartion");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($" original message : {originalMessage}");
            Console.WriteLine($" modified message : {modifiedMessage}");
            Console.WriteLine();

            byte[] key = HMAC.GenerateKey();

            var md5HashedOriginalMsg = HMAC.ComputeHMACMD5(Encoding.UTF8.GetBytes(originalMessage), key);
            var md5HashedModifiedMsg = HMAC.ComputeHMACMD5(Encoding.UTF8.GetBytes(modifiedMessage), key);

            var sha1HashedOriginalMsg = HMAC.ComputeHMACSHA1(Encoding.UTF8.GetBytes(originalMessage), key);
            var sha1HashedModifiedMsg = HMAC.ComputeHMACSHA1(Encoding.UTF8.GetBytes(modifiedMessage), key);

            var sha256HashedOriginalMsg = HMAC.ComputeHMACSHA256(Encoding.UTF8.GetBytes(originalMessage), key);
            var sha256HashedModifiedMsg = HMAC.ComputeHMACSHA256(Encoding.UTF8.GetBytes(modifiedMessage), key);

            var sha512HashedOriginalMsg = HMAC.ComputeHMACSHA512(Encoding.UTF8.GetBytes(originalMessage), key);
            var sha512HashedModifiedMsg = HMAC.ComputeHMACSHA512(Encoding.UTF8.GetBytes(modifiedMessage), key);

            Console.WriteLine("Digests");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Key: {Convert.ToBase64String(key)}");
            Console.WriteLine("MD5");
            Console.WriteLine($" original message : {Convert.ToBase64String(md5HashedOriginalMsg)}");
            Console.WriteLine($" modified message : {Convert.ToBase64String(md5HashedModifiedMsg)}");
            Console.WriteLine("SHA1");
            Console.WriteLine($" original message : {Convert.ToBase64String(sha1HashedOriginalMsg)}");
            Console.WriteLine($" modified message : {Convert.ToBase64String(sha1HashedModifiedMsg)}");
            Console.WriteLine("SHA256");
            Console.WriteLine($" original message : {Convert.ToBase64String(sha256HashedOriginalMsg)}");
            Console.WriteLine($" modified message : {Convert.ToBase64String(sha256HashedModifiedMsg)}");
            Console.WriteLine("SHA512");
            Console.WriteLine($" original message : {Convert.ToBase64String(sha512HashedOriginalMsg)}");
            Console.WriteLine($" modified message : {Convert.ToBase64String(sha512HashedModifiedMsg)}");

        }
    }
}
