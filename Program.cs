using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("Выберите действие. Введите: " +
                "\n1 для вывода данных на экран \n2 для добавления новой записи в файл \n3 для выхода");
            int action = int.Parse(Console.ReadLine());

            if (action == 1)
            {
                Print();
                Console.ReadKey();
            }
            else if (action == 2)
            {
                InputData();
            }
            else if (action == 3)
            {
                Console.WriteLine("Программа будет закрыта. Нажмите любую клавишу.");
                Console.ReadKey();
            }
        }
        static void InputData()
        {
            using (StreamWriter line = new StreamWriter("Personal.csv", true, Encoding.Unicode))
            {
                char key = 'д';

                do
                {
                    string record = string.Empty;
                    Console.WriteLine("Введите порядковый номер записи");
                    record += $"{Console.ReadLine()}#";

                    string now = DateTime.Now.ToShortTimeString();
                    Console.WriteLine($"Время записи {DateTime.Now}");
                    record += $"{DateTime.Now}#";

                    Console.WriteLine("Введите ФИО сотрудника");
                    record += $"{Console.ReadLine()}#";

                    Console.WriteLine("Введите возраст сотрудника");
                    record += $"{Console.ReadLine()}#";

                    Console.WriteLine("Введите рост сотрудника");
                    record += $"{Console.ReadLine()}#";

                    Console.WriteLine("Введите дату рождения");
                    record += $"{Console.ReadLine()}#";

                    Console.WriteLine("Введите место рождения");
                    record += $"{Console.ReadLine()}#";

                    line.WriteLine(record);
                    Console.Write("Продожить н/д\n");
                    key = Console.ReadKey(true).KeyChar;
                }
                while (char.ToLower(key) == 'д');
            }
            Out();
        }
        static void Print()
        {
            try
            {
                using (StreamReader line = new StreamReader("Personal.csv", Encoding.Unicode))
                {
                    string str;
                    Console.WriteLine($"{"ID",2}{"Дата и время",25}{"ФИО сотрудника",40}{"Возраст",10}" +
                                      $"{"Рост",10}{"Дата рождения",15}{"Место рождения",30}");

                    while ((str = line.ReadLine()) != null)
                    {
                        string[] data = str.Split('#');
                        Console.WriteLine($"{data[0],2}{data[1],25} {data[2],40}{data[3],10}{data[4],10}{data[5],15}{data[6],30}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Файл не существует!");
                Out();
            }
        }
        static void Out()
        {
            int a = 0;
            Console.WriteLine("Для возврата в меню нажмите 1, для выхода - любую клавишу");
            a = int.Parse(Console.ReadLine());
            if (a == 1)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Программа будет закрыта. Нажмите любую клавишу.");
            }
        }
    }
}

