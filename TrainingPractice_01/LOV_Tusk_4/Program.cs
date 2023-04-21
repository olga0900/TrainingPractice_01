using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOV_Tusk_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int userHealth = 5000;
            int bossHealth = 5000;
            int round = 1;
            int helpCount = 0;
            int LuckyDamageCount = 0;
            int bigUronCount = 3;
            int hideCount = 4;
            int isUserTurn = rnd.Next(0, 2);

            Console.WriteLine("Бой начинается! \n Ваше здоровье: " + userHealth + "\n Здoровье босса: " + bossHealth);
            Console.WriteLine("Ваши заклинания:");
            Console.WriteLine("1. \"урон\" - отнимает у босса от 50 до 300 единиц здоровья");
            Console.WriteLine("2. \"помощь\" - может использоваться пользователем только при условии менее 100 оставшихся единиц жизненной энергии у пользователя.\n Это заклинание прибавляет пользователю 200 единиц энергии и отнимает их у босса.Может быть применено 1 раз в 5 раундов");
            Console.WriteLine("3. \"спрятаться\" - позволяет на 1 раунд укрыться от удара босса и восстановить 50 единиц энергии");
            Console.WriteLine("4. \"удача\" - с вероятностью 50 / 50 отнимает введенное пользователем количество единиц жизненной энергии либо у босса, либо у самого пользователя.\n Это заклинание может использоваться 1 раз за всю игру");
            Console.WriteLine("5. \"большой урон\" - отнимает у босса 250 единиц здоровья и забирает у пользователя 50 единиц здоровья.\n Может использоваться 1 раз в 3 атаки");

            while (userHealth > 0 && bossHealth > 0)
            {
                if (isUserTurn == 0)
                {
                    isUserTurn = 1;
                    Console.WriteLine("Раунд " + round + ". Ваша очередь атаковать!");
                    string action = "";
                    do
                    {

                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. \"урон\"");
                        Console.WriteLine("2. \"помощь\" ");
                        Console.WriteLine("3. \"спрятаться\" ");
                        Console.WriteLine("4. \"удача\" ");
                        Console.WriteLine("5. \"большой урон\"");
                        action = Console.ReadLine();

                        switch (action)
                        {
                            case "урон":
                                int userAttack = rnd.Next(50, 301);
                                Console.WriteLine("Вы нанесли " + userAttack + " единиц урона боссу!");
                                bossHealth -= userAttack;
                                bigUronCount++;
                                hideCount++;
                                helpCount++;
                                break;
                            case "помощь":
                                if (userHealth > 100 || helpCount >= 5)
                                {
                                    Console.WriteLine("Вы не можете использовать это заклинание!");
                                    Console.WriteLine();

                                }
                                else
                                {
                                    Console.WriteLine("Вы восстановили 200 единиц здоровья и нанесли 200 урона боссу!");
                                    userHealth += 200;
                                    bossHealth -= 200;
                                    helpCount = 0;
                                    bigUronCount++;
                                    hideCount++;
                                }
                                break;
                            case "спрятаться":
                                if (hideCount >= 4)
                                {
                                    Console.WriteLine("Вы спрятались и восстановили 50 единиц здоровья!");
                                    hideCount++;
                                    userHealth += 50;
                                    hideCount = 0;
                                    bigUronCount++;
                                    helpCount++;

                                }
                                else { Console.WriteLine("Вы пока не можете использовать это заклинание! Подождите ещё " + (4 - hideCount) + " аттак(и)"); }
                                break;
                            case "удача":
                                Console.WriteLine("Введите количество урона, которое хотите нанести (помните, что с вероятностью 50% это количество отнимется у вас");
                                int LuckyDamage = int.Parse(Console.ReadLine());

                                if ((rnd.Next(0, 2) == 0) && LuckyDamageCount < 1)
                                {
                                    Console.WriteLine("Удача не на вашей стороне! Босс нанес вам " + LuckyDamage + " урона!");
                                    userHealth -= LuckyDamage;
                                    LuckyDamageCount++;
                                }
                                else if (LuckyDamageCount < 1)
                                {
                                    Console.WriteLine("Удача на вашей стороне! Вы нанесли " + LuckyDamage + " урона боссу!");
                                    bossHealth -= LuckyDamage;
                                    LuckyDamageCount++;
                                    bigUronCount++;
                                    hideCount++;
                                    helpCount++;
                                }
                                break;
                            case "большой урон":
                                if (bigUronCount >= 3)
                                {
                                    Console.WriteLine("Вы нанесли 250 урона боссу и потеряли 50 единиц здоровья!");
                                    bossHealth -= 250;
                                    userHealth -= 50;
                                    bigUronCount = 0;
                                    hideCount++;
                                    helpCount++;
                                }
                                else
                                { Console.WriteLine("Вы пока не можете использовать это заклинание! Подождите ещё " + (3 - bigUronCount) + " аттак(и)"); }
                                break;
                            default:
                                Console.WriteLine("Нужно произносить заклинания точнее!");
                                continue;
                        }
                    } while ((action == "помощь" || action == "большой урон" || action == "спрятаться" || action == "удача") && userHealth > 0 && bossHealth > 0);
                }
                else
                {
                    int bossAttack = rnd.Next(50, 301);
                    Console.WriteLine("Раунд " + round + ". Очередь босса атаковать! Босс нанес вам " + bossAttack + " урона!");
                    userHealth -= bossAttack;
                    isUserTurn = 0;
                }

                round++;
                Console.WriteLine("Ваше здоровье: " + userHealth);
                Console.WriteLine("Здoровье босса: " + bossHealth);
                Console.WriteLine();
            }
            if (userHealth < 0)

            { Console.WriteLine("Вы проиграли(("); }
            else { Console.WriteLine("Вы победили!!"); }
            Console.ReadLine();
        }
    }
        }
