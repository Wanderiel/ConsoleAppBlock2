using System;

namespace ConsoleAppB2P6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string LookAroundCommand = "1";
            const string RememberCommand = "2";
            const string OpenChestCommand = "3";
            const string DrinkHealthPotionCommand = "4";
            const string GoHomeCommand = "5";

            Random random = new Random();

            bool isWork = true;
            bool isChest = false;
            bool isChestOpen = false;
            bool havePotion = false;
            bool haveRope = false;

            int maxHeath = 100;
            int halfHealth = maxHeath / 2;
            int health = random.Next(halfHealth);
            int healthPotionCount = 0;

            string name = "?????";
            string trueName = "Владислав";
            string userInput;

            ConsoleColor colorForeGoround = ConsoleColor.DarkGreen;
            ConsoleColor colorForeGoroundHealth = ConsoleColor.DarkRed;

            Console.ForegroundColor = colorForeGoround;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();

            Console.WriteLine($"Имя: {name}");

            Console.ForegroundColor = colorForeGoroundHealth;
            Console.WriteLine($"Здоровье: {health}/{maxHeath}\n");
            Console.ForegroundColor = colorForeGoround;

            Console.WriteLine("Вы открываете глаза, голова гудит, всё тело ломит. Потихоньку чувства к вам возвращаются.\n" +
                "Приподнявшись, вы хватаетесь за голову...\n\n");

            while (isWork)
            {
                Console.WriteLine($"{LookAroundCommand}. Осмотреться" +
                    $"\n{RememberCommand}. Попытаться что-нибудь вспомнить");

                if (isChest)
                    Console.WriteLine($"{OpenChestCommand}. Открыть сундук");

                if (havePotion)
                    Console.WriteLine($"{DrinkHealthPotionCommand}. Выпить зелье");

                if (haveRope)
                    Console.WriteLine($"{GoHomeCommand}. Вылезти из расщелины");

                Console.Write("\nВаши действия... ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case LookAroundCommand:
                        Console.WriteLine("\nВы осматриваетесь вокруг. Рядом с вам сундук, вокруг, похоже, ни души.\n" +
                            "Вы пытальсь достать его с той самой высоты, а теперь застряли в расщелине.");

                        if (health < maxHeath)
                            Console.WriteLine("Очень болит бок, на затылке вы чуствуете кровь. " +
                                "Похоже можно умерееть от кровотечения.");
                        else
                            Console.WriteLine("Всё ещё чувствуется кровь, но раны уже затянулись, " +
                                "опасность смерти от кровотечения позади.");

                        isChest = true;
                        break;

                    case RememberCommand:
                        Console.WriteLine("\nВы погружаетесь в недра своего сознания, пытаясь вспомнить " +
                            $"кто вы и что здесь делаете. Кажется вас зовут {trueName}.");

                        name = trueName;
                        break;

                    case OpenChestCommand:
                        if (isChest)
                        {
                            if (isChestOpen)
                            {
                                Console.WriteLine("В сундуке больше ничего нет, он пуст!");
                            }
                            else
                            {
                                Console.WriteLine("\nВы подтягиваете небольшой сундук к себе и пытаетесь " +
                                    "его открыть. Шансы не велики...");

                                int maxChance = 100;
                                int chanceToOpen = 33;

                                while (isChestOpen == false && health > 0)
                                {
                                    if (random.Next(maxChance) <= chanceToOpen)
                                    {
                                        Console.WriteLine("Замок поддаётся и вы обнаруживаете в сундуке верёвку и зелье.");

                                        isChestOpen = true;
                                        healthPotionCount++;
                                        havePotion = true;
                                        haveRope = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("К сожалению замок только ехидно щёлкает в ответ, но " +
                                            "никак не поддаётся. вы продолжаете пытаться...");

                                        health--;
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        break;

                    case DrinkHealthPotionCommand:
                        if (havePotion)
                        {
                            if (healthPotionCount > 0)
                            {
                                Console.WriteLine("\nВы откупориваете пузырёк и жадно пьёте содержимое.\n" +
                                    "Немного погодя вы чувствуте как затягиваются ваши мелкие ссадины и глубокие раны.");

                                colorForeGoroundHealth = colorForeGoround;
                                health = maxHeath;
                                healthPotionCount--;
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас больше нет зелий, а этот пузырёк уже пуст.");
                            }
                        }
                        break;

                    case GoHomeCommand:
                        Console.WriteLine("\nВы пытаетесь закинуть верёвку наверх в надежде, что она за что-то зацепиться...");

                        if (health == maxHeath)
                        {
                            Console.WriteLine("Удачный бросок, вы дёргаете верёвку пару раз, что бы убедиться, " +
                                "что она надёжно закрепилась." +
                                "\nЧерез пару-тройку минут вы оказываетесь наверху.");

                            isWork = false;
                        }
                        else
                        {
                            Console.WriteLine("Но резкая боль в боку не даёт вам нормально это сделать и " +
                                "ваша попатка оборачивается неудачей.");
                        }
                        break;

                    default:
                        Console.Write("\nБездействие тоже действие...");
                        break;
                }

                Console.ReadKey();

                if (health > 0 && health < maxHeath)
                    health--;

                if (isWork)
                {
                    Console.Clear();
                    Console.WriteLine($"Имя: {name}");

                    Console.ForegroundColor = colorForeGoroundHealth;
                    Console.WriteLine($"Здоровье: {health}/{maxHeath}\n");
                    Console.ForegroundColor = colorForeGoround;
                }
                else
                {
                    Console.ResetColor();
                    Console.Clear();

                    if (name == trueName)
                        Console.WriteLine("Свобода!!! И можно идти домой...");
                    else
                        Console.WriteLine("Свобода!!! И... можно было бы пойти домой, если бы вы помнили, где он...");
                }

                if (health <= 0)
                {
                    Console.WriteLine("\nК сожалению вы не смогли... вы мертвы!");
                    isWork = false;
                }
            }

            Console.ReadKey();
        }
    }
}