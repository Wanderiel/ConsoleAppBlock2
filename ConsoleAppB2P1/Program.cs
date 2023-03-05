using System;

namespace ConsoleAppB2P1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            int countOfRepetitions;

            Console.Write("Повторение - Мать заикания!\nКакую фразу для вас повторить: ");
            text = Console.ReadLine();

            Console.Write("Сколько раз это сделать: ");
            countOfRepetitions = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            for (int i = 0; i < countOfRepetitions; i++)
            {
                Console.WriteLine(text);
            }

            Console.ReadKey();
        }
    }
}