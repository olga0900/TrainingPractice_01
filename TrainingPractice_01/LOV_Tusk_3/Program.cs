using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOV_Tusk_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string password = "89675210091";
            string user;
            do
            {
                Console.Write("Введите пароль: ");
                user = Console.ReadLine();
                if (user != password) counter++;
                else
                {
                    Console.WriteLine("Секретное сообщение: молодец");
                    counter = 3;
                }
            } while (counter < 3);
            Console.ReadKey();
        }
    }
}
