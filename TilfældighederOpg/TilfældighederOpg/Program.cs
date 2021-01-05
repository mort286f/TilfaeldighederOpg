using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TilfældighederOpg
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumber rn = new RandomNumber();
            Stopwatch watch = new Stopwatch();

            Console.WriteLine("Random:");
            watch.Start();
            rn.GetRandomNumber();
            watch.Stop();

            Console.WriteLine("\nRandom elapsed time: " + watch.ElapsedTicks.ToString());
            Console.WriteLine();

            Console.WriteLine("CryptoServiceProvider");
            watch.Start();
            rn.GetCryptoServiceProviderNumber();
            watch.Stop();

            Console.WriteLine("\nCryptoServiceProvider elapsed time: " + watch.ElapsedTicks.ToString());
            Console.ReadKey();
        }
    }

    class RandomNumber
    {
        public void GetCryptoServiceProviderNumber()
        {
            int randomNumber;
            byte[] data = new byte[4];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {

                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);

                    randomNumber = BitConverter.ToInt32(data, 0);
                    Console.Write($"{randomNumber},  ");
                }
            }
        }

        public void GetRandomNumber()
        {
            Random rndm = new Random(100);

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{rndm.Next(0, 100)},  ");
            }
        }
    }
}
