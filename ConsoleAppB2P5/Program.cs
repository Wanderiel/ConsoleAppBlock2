using System;

namespace ConsoleAppB5P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandDollarToRuble = "1";
            const string CommandRubleToDollar = "2";
            const string CommandDollarToCrown = "3";
            const string CommandCrownToDollar = "4";
            const string CommandCrownToRuble = "5";
            const string CommandRubleToCrown = "6";
            const string CommandExit = "7";

            Random random = new Random();
            int doubleMultiplier = 100;
            int rounding = 2;
            double dollars = Math.Round(random.NextDouble() * doubleMultiplier, rounding);
            double rubles = Math.Round(random.NextDouble() * doubleMultiplier, rounding);
            double crowns = Math.Round(random.NextDouble() * doubleMultiplier, rounding);
            double courseDollarToRuble = 33.5;
            double courseDollarToCrown = 1.25;
            double courseCrownToRubel = 26.8;
            string userInput;
            int result;
            double convertValue = 0;
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Добро пожаловать в валютную кассу!\n\nВы можете:\n" +
                    $"{CommandDollarToRuble}. Перевести доллары в рубли\n" +
                    $"{CommandRubleToDollar}. Перевести рубли в доллары\n" +
                    $"{CommandDollarToCrown}. Перевести доллары в кроны\n" +
                    $"{CommandCrownToDollar}. Перевести кроны в доллары\n" +
                    $"{CommandCrownToRuble}. Перевести кроны в рубли\n" +
                    $"{CommandRubleToCrown}. Перевести рубли в кроны\n" +
                    $"{CommandExit}. Выход");

                Console.SetCursorPosition(0, 16);
                Console.WriteLine($"У вас:\nдолларов - {dollars}\n" +
                    $"рублей - {rubles}\n" +
                    $"крон - {crowns}");
                Console.SetCursorPosition(0, 11);

                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out result))
                {
                    if (result >= Convert.ToInt32(CommandDollarToRuble) && result < Convert.ToInt32(CommandExit))
                    {
                        Console.WriteLine("Сколько хотите перевести:");
                        convertValue = Math.Round(Convert.ToDouble(Console.ReadLine()), rounding);
                    }
                }

                switch (userInput)
                {
                    case CommandDollarToRuble:
                        if (dollars >= convertValue)
                        {
                            dollars = Math.Round(dollars -= convertValue, rounding);
                            rubles = Math.Round(rubles += convertValue * courseDollarToRuble, rounding);
                        }
                        break;

                    case CommandRubleToDollar:
                        if (rubles >= convertValue)
                        {
                            rubles = Math.Round(rubles -= convertValue, rounding);
                            dollars = Math.Round(dollars += convertValue / courseDollarToRuble, rounding);
                        }
                        break;

                    case CommandDollarToCrown:
                        if (dollars >= convertValue)
                        {
                            dollars = Math.Round(dollars -= convertValue, rounding);
                            crowns = Math.Round(crowns += convertValue * courseDollarToCrown, rounding);
                        }
                        break;

                    case CommandCrownToDollar:
                        if (crowns >= convertValue)
                        {
                            crowns = Math.Round(crowns -= convertValue, rounding);
                            dollars = Math.Round(dollars += convertValue / courseDollarToCrown, rounding);
                        }
                        break;

                    case CommandCrownToRuble:
                        if (crowns >= convertValue)
                        {
                            crowns = Math.Round(crowns -= convertValue, rounding);
                            rubles = Math.Round(rubles += convertValue * courseCrownToRubel, rounding);
                        }
                        break;

                    case CommandRubleToCrown:
                        if (rubles >= convertValue)
                        {
                            rubles = Math.Round(rubles -= convertValue, rounding);
                            crowns = Math.Round(crowns += convertValue / courseCrownToRubel, rounding);
                        }
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Всего доброго!");

            Console.ReadKey();
        }
    }
}