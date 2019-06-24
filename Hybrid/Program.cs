using System;
using System.Text;

namespace Hybrid
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsaParams = new RSAWithRSAParameterKey();

            const string originalData = 
                "So, what if, instead of thinking about solving your whole life, you just think about " +
                "adding additional good things. One at a time. Just let your pile of good things grow!";

            rsaParams.AssignNewKey();

            var hybrid = new HybridEncryption();

            var encryptedPacket = hybrid.EncryptData(Encoding.UTF8.GetBytes(originalData), rsaParams);
            var decryptedData = hybrid.DecryptData(encryptedPacket, rsaParams);

            Console.WriteLine("Hybrid Encryption using in Memory keys");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" original data  : {originalData}");
            Console.WriteLine("");  
            Console.WriteLine($" decrypted data : {Encoding.Default.GetString(decryptedData)}");
            Console.WriteLine("");
        }
    }
}
