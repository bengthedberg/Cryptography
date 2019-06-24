using System;
using System.Text;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAWithRSAParameterKey();
            RSAWithXMLKey();
            RSAWithCSPKey();
        }

        private static void RSAWithCSPKey()
        {
            var rsaParams = new RSAWithCSPKey();

            const string originalData = "Data To Encrypt";

            rsaParams.AssignKey();

            var encryptedData = rsaParams.EncryptData(Encoding.UTF8.GetBytes(originalData));
            var decryptedData = rsaParams.DecryptData(encryptedData);

            rsaParams.DeleteKey();

            Console.WriteLine("RSA Encryption using Windows Secure Key Container");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" original data  : {originalData}");
            Console.WriteLine($" encrypted data : {Convert.ToBase64String(encryptedData)}");
            Console.WriteLine($" decrypted data : {Encoding.Default.GetString(decryptedData)}");
            Console.WriteLine("");
        }

        private static void RSAWithXMLKey()
        {
            var rsaParams = new RSAWithXMLKey();

            const string originalData = "Data To Encrypt";
            const string publicKey  = @"C:\Temp\PublicKey.xml";
            const string privateKey = @"C:\Temp\PrivateKey.xml";


            rsaParams.AssignKey(publicKey, privateKey);

            var encryptedData = rsaParams.EncryptData(publicKey, Encoding.UTF8.GetBytes(originalData));
            var decryptedData = rsaParams.DecryptData(privateKey, encryptedData);

            Console.WriteLine("RSA Encryption using keys in XML Files");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" original data  : {originalData}");
            Console.WriteLine($" encrypted data : {Convert.ToBase64String(encryptedData)}");
            Console.WriteLine($" decrypted data : {Encoding.Default.GetString(decryptedData)}");
            Console.WriteLine("");
        }

        private static void RSAWithRSAParameterKey()
        {
            var rsaParams = new RSAWithRSAParameterKey();

            const string originalData = "Data To Encrypt";

            rsaParams.AssignKey();

            var encryptedData = rsaParams.EncryptData(Encoding.UTF8.GetBytes(originalData));
            var decryptedData = rsaParams.DecryptData(encryptedData);

            Console.WriteLine("RSA Encryption using in Memory keys");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" original data  : {originalData}");
            Console.WriteLine($" encrypted data : {Convert.ToBase64String(encryptedData)}");
            Console.WriteLine($" decrypted data : {Encoding.Default.GetString(decryptedData)}");
            Console.WriteLine("");
        }
    }
}
