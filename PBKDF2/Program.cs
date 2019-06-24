using System;
using System.Diagnostics;
using System.Text;

namespace PBKDF2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string password = "MySecurePassword";
            byte[] salt = PBKDF2.GenerateSalt();

            Console.WriteLine("Password Based Key Deriviation Function (PBKDF) Demonstartion");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($" password : {password}");
            Console.WriteLine($" salt     : {Convert.ToBase64String(salt)}");
            Console.WriteLine();

            GenerateHash(Encoding.UTF8.GetBytes(password), salt,      10);
            GenerateHash(Encoding.UTF8.GetBytes(password), salt,     100);
            GenerateHash(Encoding.UTF8.GetBytes(password), salt,    1000);
            GenerateHash(Encoding.UTF8.GetBytes(password), salt,   10000);
            GenerateHash(Encoding.UTF8.GetBytes(password), salt,   50000);
            GenerateHash(Encoding.UTF8.GetBytes(password), salt,  100000);
            GenerateHash(Encoding.UTF8.GetBytes(password), salt, 1000000);

            Console.WriteLine();
        }

        static void GenerateHash(byte[] password, byte[] salt, int iterations)
        {
            var sw = new Stopwatch();

            sw.Start();

            var digest = PBKDF2.HashPassword(password, salt, iterations);

            sw.Stop();

            Console.WriteLine($" digest : {Convert.ToBase64String(digest)}");
            Console.WriteLine($" iteranions <{iterations}> time {sw.ElapsedMilliseconds}");
            

        }
    }
}
