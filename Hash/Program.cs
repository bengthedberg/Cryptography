using System;
using System.Text;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            const string originalMessage = "This is a message";
            const string modifiedMessage = "Th!s is a message";

            Console.WriteLine("Secure Hash Data Demonstartion");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine($" original message : {originalMessage}");
            Console.WriteLine($" modified message : {modifiedMessage}");
            Console.WriteLine();

            var md5HashedOriginalMsg = HashData.ComputeHashMD5(Encoding.UTF8.GetBytes(originalMessage));
            var md5HashedModifiedMsg = HashData.ComputeHashMD5(Encoding.UTF8.GetBytes(modifiedMessage));

            var sha1HashedOriginalMsg = HashData.ComputeHashSHA1(Encoding.UTF8.GetBytes(originalMessage));
            var sha1HashedModifiedMsg = HashData.ComputeHashSHA1(Encoding.UTF8.GetBytes(modifiedMessage));

            var sha256HashedOriginalMsg = HashData.ComputeHashSHA256(Encoding.UTF8.GetBytes(originalMessage));
            var sha256HashedModifiedMsg = HashData.ComputeHashSHA256(Encoding.UTF8.GetBytes(modifiedMessage));

            var sha512HashedOriginalMsg = HashData.ComputeHashSHA512(Encoding.UTF8.GetBytes(originalMessage));
            var sha512HashedModifiedMsg = HashData.ComputeHashSHA512(Encoding.UTF8.GetBytes(modifiedMessage));

            Console.WriteLine("Digests");
            Console.WriteLine("------------------------------");
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
