using System;

namespace ConsoleAppB2P10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int maxRandom = 1000;
            int randomNumber = random.Next(maxRandom);
            int number = 1;
            int power = 0;
            int baseNumber = 2;

            while (number <= randomNumber)
            {
                number *= baseNumber;
                power++;
            }

            Console.WriteLine($"Загадано число: {randomNumber}. Найдено число {number} как {baseNumber} в степени {power}");

            Console.ReadKey();
        }
    }
}