using System;
using System.Text;

namespace HybridWithSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            const string originalData =
                "So, what if, instead of thinking about solving your whole life, you just think about " +
                "adding additional good things. One at a time. Just let your pile of good things grow!";

            var rsaParams = new RSAWithRSAParameterKey();
            rsaParams.AssignNewKey();
            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            var hybrid = new HybridEncryption();

            try
            {
                Console.WriteLine("Hybrid Encryption using in Memory keys");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
                Console.WriteLine($" original data  : {originalData}");

                var encryptedPacket = hybrid.EncryptData(Encoding.UTF8.GetBytes(originalData), rsaParams, digitalSignature);
                var decryptedData = hybrid.DecryptData(encryptedPacket, rsaParams, digitalSignature);

                Console.WriteLine("");
                Console.WriteLine($" decrypted data : {Encoding.Default.GetString(decryptedData)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("");
        }
    }
}
