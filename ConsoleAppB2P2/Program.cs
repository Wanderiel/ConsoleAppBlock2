using System;

namespace ConsoleAppB2P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = string.Empty;
            string codeWord = "exit";
            int count = 1;
            int repeatNumber = 10;

            Console.WriteLine($"Здравствуйте. Я буду заправшивать у вас кодовое слово. Постоянно, пока не услышу - \"{codeWord}\".\n");

            while (password.ToLower() != codeWord)
            {
                if (count % repeatNumber == 0)
                {
                    Console.Write($"Ведите кодовое слово (напоминаю, это слово \"{codeWord}\"): ");
                    count = 1;
                }
                else
                {
                    Console.Write("Ведите кодовое слово: ");
                }

                password = Console.ReadLine();

                count++;
            }

            Console.WriteLine("\nСпасибо! Заходите как-нибудь ещё.");
            Console.ReadKey();
        }
    }
}