using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RandomNumbers
{
    public class Random
    {
        public static byte[] GenerateRandomNumbers(int length)
        {
            using ( var rng = new RNGCryptoServiceProvider())
            {
                var randomNumbers = new byte[length];
                rng.GetBytes(randomNumbers);

                return randomNumbers;
            }
        }
    }
}
