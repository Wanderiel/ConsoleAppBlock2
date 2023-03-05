using System;

namespace ConsoleAppB2P7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            char symbol;
            string charsString = string.Empty;
            string nameBetweenSymbol;

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();

            Console.Write("Ведите символ: ");
            symbol = Console.ReadLine().First();

            nameBetweenSymbol = symbol + name + symbol;

            for (int i = 0; i < nameBetweenSymbol.Length; i++)
            {
                charsString += symbol;
            }

            Console.WriteLine($"\n{charsString}\n{nameBetweenSymbol}\n{charsString}");

            Console.ReadKey();
        }
    }
}