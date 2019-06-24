using System;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Random Number Demonstration in .NET");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("");

            for (int i = 0; i < 10; i++)
            {
                // ToBase64String is used to convert the byte array tp a readable form that we can display
                Console.WriteLine($"Random Number {i} : {Convert.ToBase64String(Random.GenerateRandomNumbers(32))}");
            }

        }
    }
}
