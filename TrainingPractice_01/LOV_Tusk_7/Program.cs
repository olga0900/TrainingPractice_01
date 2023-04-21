using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOV_Tusk_7
{
    internal class Program
        {
             private static Random random = new Random();

        static void Main(string[] args)
        {
            var masLength = GetParseInt("длинну массива");
            var mas = new int[masLength];

            for (int i = 0; i < masLength; i++)
            {
                mas[i] = random.Next(0, 100);
            }
            PrintArray(mas, "\nИсходный массив");
            Shuffle(ref mas, 50);
            PrintArray(mas, "Перемешанный массив");
            Console.ReadLine();
        }

        public static int GetParseInt(string str)
        {
            while (true)
            {
                Console.Write("Введите " + str + ": ");
                if (Int32.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("Ввод некорректный!");
            }
        }

        public static void Shuffle(ref int[] mas, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var index1 = random.Next(0, mas.Length);
                var index2 = random.Next(0, mas.Length);
                (mas[index1], mas[index2]) = (mas[index2], mas[index1]);
            }
        }

        public static void PrintArray(int[] array, string str)
        {
            Console.WriteLine($"{str}");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
