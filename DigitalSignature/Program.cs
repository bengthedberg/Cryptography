using System;
using System.Security.Cryptography;
using System.Text;

namespace DigitalSignature
{
    class Program
    {
        static void Main(string[] args)
        {

            var document = Encoding.UTF8.GetBytes("Imprtant Document to sign");
            byte[] hashedDocument;


            using (var sha256 = SHA256.Create())
            {
                hashedDocument = sha256.ComputeHash(document);

            }

            var digitalSignature = new DigitalSignature();

            digitalSignature.AssignNewKey();

            var signature = digitalSignature.SignData(hashedDocument);
            var verified = digitalSignature.VerifySignature(hashedDocument, signature);

            Console.WriteLine("Digital Signature Demonstration");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" original text  : {Encoding.Default.GetString(document)}");
            Console.WriteLine($" signature      : {Convert.ToBase64String(signature)}");
            Console.WriteLine($" verified       : {verified}");
            Console.WriteLine("");
        }
    }
}
