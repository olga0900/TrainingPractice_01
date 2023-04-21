using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOV_Tusk_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] posts = new string[0];
            string[] fullPeople = new string[0];
            bool isExitProgram = true;

            while (isExitProgram)
            {
                Console.Clear();
                Console.WriteLine("Отдел кадров:");
                Console.WriteLine();
                Console.WriteLine("Добавить досье             1");
                Console.WriteLine("Вывод всех досье           2 ");
                Console.WriteLine("Удалить досье по индексу   3 ");
                Console.WriteLine("Поиск досье по фамилии     4");
                Console.WriteLine("Выход из программы         5\n");
                Console.Write("\nВыберите пункт ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine();
                        AddDossier(ref fullPeople, ref posts);
                        break;
                    case "2":
                        Console.WriteLine();
                        ShowAllDossiers(posts, fullPeople);
                        break;
                    case "3":
                        Console.WriteLine();
                        DeleteDossier(ref fullPeople, ref posts);
                        break;
                    case "4":
                        Console.WriteLine();
                        SearchDossier(fullPeople, posts);
                        break;
                    case "5":
                        isExitProgram = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" Неправильный ввод ");
                        break;
                }
                Console.Write("Нажмите любую клавишу для того чтобы продолжить");
                Console.ReadKey();
            }
        }

        private static void AddDossier(ref string[] names, ref string[] positions)
        {
            bool Check = true;
            Console.WriteLine("Добавление досье ");
            string[] name = new string[3];
            Console.WriteLine("Введите ФИО сотрудника");
            while (Check)
            {
                Console.Write("Фамилия - ");
                name[0] = Console.ReadLine();
                Check = int.TryParse(name[0], out _);
            }
            Check = true;
            while (Check)
            {
                Console.Write("Имя - ");
                name[1] = Console.ReadLine();
                Check = int.TryParse(name[1], out _);
            }
            Check = true;
            while (Check)
            {
                Console.Write("Отчество - ");
                name[2] = Console.ReadLine();
                Check = int.TryParse(name[2], out _);
            }
            Console.Write("Введите должность сотрудника - ");
            string post = Console.ReadLine();
            string name2 = string.Join(" ", name);

            names = AddArrayDossier(names, name2);
            positions = AddArrayDossier(positions, post);
            Console.WriteLine("\n Досье добавлено \n");
        }

        private static string[] AddArrayDossier(string[] array, string text)
        {
            string[] dopArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                dopArray[i] = array[i];
            }
            dopArray[dopArray.Length - 1] = text;
            array = dopArray;
            return array;
        }

        private static void ShowAllDossiers(string[] posts, string[] fullPeople)
        {
            int index = 1;
            if (posts.Length == 0)
            {
                Console.WriteLine(" Данные отсутствуют \n");
            }
            else
            {
                Console.WriteLine(" Вывод всех досье: ");
                for (int i = 0; i < posts.Length; i++)
                {
                    Console.WriteLine($"{index}| ФИО: {fullPeople[i]}   | {posts[i]}");
                    index++;
                }
                Console.WriteLine();
            }
        }

        private static void DeleteDossier(ref string[] fullPeople, ref string[] posts)
        {
            bool Check = false;
            string str = "";
            while (!Check)
            {
                Console.Write("Введите номер досье для удаления - ");
                str = Console.ReadLine();
                Check = int.TryParse(str, out _);
            }
            int number = Convert.ToInt32(str);

            if (number > 0 && number <= fullPeople.Length)
            {
                int index = number - 1;
                fullPeople = DeleteArrayDossier(fullPeople, index);
                posts = DeleteArrayDossier(posts, index);
                Console.WriteLine($" Досье с номером ({number}) удалено ");
            }
            else
            {
                Console.WriteLine(" Досье с таким номером отсутствует ");
            }
        }

        private static string[] DeleteArrayDossier(string[] array, int index)
        {
            string[] dopArray = new string[array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                dopArray[i] = array[i];
            }
            for (int i = index; i < array.Length - 1; i++)
            {
                dopArray[i] = array[i + 1];
            }
            array = dopArray;
            return array;
        }

        private static void SearchDossier(string[] fullPeople, string[] posts)
        {
            Console.Write("Введите фамилию для поиска досье - ");
            string surname = Console.ReadLine();
            bool Check = false;
            int number = 0;

            for (int i = 0; i < fullPeople.Length; i++)
            {
                string[] split = fullPeople[i].Split(' ');
                if (split[0].ToLower() == surname.ToLower())
                {
                    number++;
                    Console.WriteLine($"{i + 1} ФИО: {fullPeople[i]}   - {posts[i]}");
                    Check = true;
                }
            }
            Console.WriteLine($"\n Количество сотрудников с фамилией '{surname}' #{number} ");
            if (!Check)
            {
                Console.WriteLine($" Сотрудники с фамилией '{surname}' не найдены ");
            }
        }
}
    }
