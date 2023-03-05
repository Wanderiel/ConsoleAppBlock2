using System;

namespace ConsoleAppB2P12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SpellMagicKick = 0;
            const int SpellCapriciousWave = 1;
            const int SpellBurningSnowstorm = 2;
            const int SpellPlayfulBird = 3;
            const int SpellSnottWorm = 0;
            const int SpellRottenBouquet = 1;
            const int SpellDarkKiss = 2;
            const int SpellCallShadow = 3;

            Random random = new Random();

            int spellRamdom = 3;
            int bossMinValue = 300;
            int playerMinValue = 200;
            int readableSpell;
            int lifetimeShadow = 5;
            int timerShadow = 0;
            int cooldownKiss = 3;
            int timerKiss = 0;
            int cooldownPlayfulBird = 3;
            int timerPlayfulBird = 0;

            bool isBattle = true;

            double bossHealth = Math.Round(random.NextDouble() * bossMinValue + bossMinValue);
            double halfBossHealth = Math.Round(bossHealth / 2);
            double bossMana = Math.Round(random.NextDouble() * bossMinValue + bossMinValue);
            double bossManaCost = 8;
            double bossDamage = 40;

            double playerHealth = Math.Round(random.NextDouble() * playerMinValue + playerMinValue);
            double halfPlayerHealth = Math.Round(playerHealth / 2);
            double playerMana = Math.Round(random.NextDouble() * playerMinValue + playerMinValue);
            double playerManaCost = 5;
            double playerDamage = 30;

            double trueDamage = 0;
            double distance = 100;
            double step = 20;
            double spellRange = 120;

            Console.WriteLine("Легенда: Вы – полевой маг и у вас в арсенале есть несколько заклинаний, " +
                "которые вы будете использовать против Босса. Вы должны уничтожить Босса и только после " +
                "этого будет вам покой.\nПримечание: используется автобой, заклинания выбираются из " +
                "арсенанла рандомно.\n");
            Console.WriteLine($"Босс: {bossHealth} здоровья | {bossMana} маны" +
                $"\nИгрок: {playerHealth} здоровья | {playerMana} маны");

            Console.ReadKey();

            while (isBattle)
            {
                #region Игрок

                if (playerHealth < halfPlayerHealth)
                    readableSpell = SpellPlayfulBird;
                else
                    readableSpell = random.Next(spellRamdom);

                if (readableSpell == SpellPlayfulBird)
                {
                    if (playerMana > playerManaCost * readableSpell &&
                        timerPlayfulBird == 0)
                    {
                        double health = 100;

                        timerPlayfulBird = cooldownPlayfulBird;

                        Console.WriteLine($"Игорок применяет заклинание \"Игривая птица\" " +
                            $"и восстанавливает себе {health} здоровья");

                        trueDamage = 0;
                        playerHealth += health;
                    }
                    else
                    {
                        readableSpell = SpellBurningSnowstorm;
                    }
                }

                if (readableSpell == SpellBurningSnowstorm)
                {
                    if (distance - step < spellRange / readableSpell &&
                        playerMana > playerManaCost * readableSpell)
                    {
                        distance -= step;
                        trueDamage = playerDamage * readableSpell + playerDamage;

                        Console.WriteLine($"Игрок применяет заклинание \"Жгучая метель\" и " +
                        $"наносит урон боссу {trueDamage}");
                    }
                    else
                    {
                        readableSpell = SpellCapriciousWave;
                    }
                }

                if (readableSpell == SpellCapriciousWave)
                {
                    if (distance - step < spellRange / readableSpell &&
                        playerMana > playerManaCost * readableSpell)
                    {
                        distance -= step;
                        trueDamage = playerDamage * readableSpell + playerDamage;

                        Console.WriteLine($"Игрок применяет заклинание \"Капризная волна\" и " +
                        $"наносит урон боссу {trueDamage}");
                    }
                    else
                    {
                        readableSpell = SpellMagicKick;
                    }
                }

                if (readableSpell == SpellMagicKick)
                {
                    if (distance > step * SpellPlayfulBird)
                        distance -= step;

                    trueDamage = playerDamage;

                    Console.WriteLine($"Игрок применяет фокус \"Волшебный пендаль\" и " +
                        $"наносит урон боссу {trueDamage}");
                }

                playerMana -= playerManaCost * readableSpell;
                bossHealth -= trueDamage;

                if (timerPlayfulBird > 0)
                    timerPlayfulBird--;

                #endregion

                #region Босс

                if (bossHealth < halfBossHealth)
                    readableSpell = SpellCallShadow;
                else
                    readableSpell = random.Next(spellRamdom);

                if (readableSpell == SpellCallShadow)
                {
                    if (bossMana > bossManaCost * readableSpell && timerShadow == 0)
                    {
                        timerShadow = lifetimeShadow;
                        trueDamage = 0;

                        Console.WriteLine("Босс призывает Тень.");
                    }
                    else
                    {
                        readableSpell = SpellDarkKiss;
                    }
                }

                if (readableSpell == SpellDarkKiss)
                {
                    if (bossMana > bossManaCost * readableSpell &&
                        timerShadow > 0 && timerKiss == 0)
                    {
                        double health = 40;

                        timerKiss = cooldownKiss;
                        trueDamage = bossDamage * readableSpell;

                        Console.WriteLine("Босс применяет заклинание \"Мрачный поцелуй\" и " +
                            $"восстанавливает себе {health} здоровья, а так же наносит игроку " +
                            $"{trueDamage} урона");
                    }
                    else
                    {
                        readableSpell = SpellRottenBouquet;
                    }
                }

                if (readableSpell == SpellRottenBouquet)
                {
                    if (bossMana > bossManaCost * readableSpell)
                    {
                        trueDamage = bossDamage * readableSpell;

                        Console.WriteLine("Босс применил заклинание \"Гнилой букет\" и " +
                            $"нанёс игроку {trueDamage} урона.");
                    }
                    else
                    {
                        readableSpell = SpellSnottWorm;
                    }
                }

                if (readableSpell == SpellSnottWorm)
                {
                    trueDamage = bossDamage;

                    Console.WriteLine("Босс применил заклинание \"Сопливый червь\" и " +
                        $"нанёс игроку {trueDamage} урона.");
                }

                bossMana -= bossManaCost * readableSpell;
                playerHealth -= trueDamage;

                if (timerShadow > 0)
                    timerShadow--;

                if (timerKiss > 0)
                    timerKiss--;

                #endregion

                Console.WriteLine($"\nБосс: {bossHealth} здоровья | {bossMana} маны" +
                    $"\nИгрок: {playerHealth} здоровья | {playerMana} маны");

                Console.ReadKey();
                if (bossHealth < 0 || playerHealth < 0)
                    isBattle = false;
            }

            if (bossHealth < 0 && playerHealth < 0)
                Console.WriteLine("\nНичья, вы погибли, но и Босс тоже убит...");
            else if (bossHealth < 0)
                Console.WriteLine("\nВы победили! Босс мёртв! Наконец-то покой...");
            else
                Console.WriteLine("\nВы проиграли. Теперь вам не знать покоя. " +
                    "Будете прислуживать Боссу в качестве Тени...");

            Console.ReadKey();
        }
    }
}