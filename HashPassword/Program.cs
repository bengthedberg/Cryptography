using System;
using System.Text;

namespace HashPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            const string password = "MySecurePassword";
            byte[] salt  = Hash.GenerateSalt();

            Console.WriteLine("Salted Hash Password Demonstartion");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Console.WriteLine($" password : {password}");
            Console.WriteLine($" salt     : {Convert.ToBase64String(salt)}");
            Console.WriteLine();

            var saltedPassword  = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);

            Console.WriteLine($" salted password  : {Convert.ToBase64String(saltedPassword)}");
            Console.WriteLine();
        }
    }
}
