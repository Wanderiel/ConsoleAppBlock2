using System;

namespace ConsoleAppB2P9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int minNumber = 100;
            int maxNumber = 999;
            int minRandom = 1;
            int maxRandom = 28;
            int number = rand.Next(minRandom, maxRandom);
            int count = 0;

            for (int i = 0; i <= maxNumber; i += number)
            {
                if (i >= minNumber)
                    count++;
            }

            Console.WriteLine($"Количество трёхзначных чисел кратных {number}: {count}");

            Console.ReadKey();
        }
    }
}