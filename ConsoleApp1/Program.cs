using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table[] tables = {
                new Table(1, 3),
                new Table(2, 5),
                new Table(3, 6),
                new Table(4, 7)
            };
            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(0, 18);
                foreach (Table table in tables)
                {
                    table.ShowInfo();
                }

                //Console.ReadKey();
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Введите операцию, которую хотите выполнить");
                Console.WriteLine("1 - забронировать стол" +
                    "\n2 - ничего не делать");
                int command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        Console.WriteLine("Сейчас порешаем");
                        Console.WriteLine("Введите номер стола для брони");
                        int numberTable = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (numberTable < tables.Length)
                        {
                            Console.WriteLine("Введите количество мест");
                            int numberPlaces = Convert.ToInt32(Console.ReadLine());
                            tables[numberTable].ReserveTable(numberPlaces);
                        }
                        else
                        {
                            Console.WriteLine("Невозможно выбрать этот стол");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Ну и пошёл в жопу урод");
                        break;
                    default:
                        Console.WriteLine("ты что в глаза долбишься, " +
                            "нет такой операции");
                        break;
                }
            }
            //Console.SetCursorPosition(11, 12);
            //int[] x = { 1, 2, 3, 4 };
            //for (int i = 0; i < x.Length; i++)
            //{
            //    Console.WriteLine($"{x[i]} ");
            //}
            //Console.CursorVisible = false;
            //char[,] map =
            //{
            //    {'#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            //    {'#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
            //};
            //int userX = 1; int userY = 1;
            //while (true)
            //{
            //    Console.SetCursorPosition(0, 0);
            //    for (int i = 0; i < map.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < map.GetLength(1); j++)
            //        {
            //            Console.Write(Convert.ToString(map[i, j]));
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.SetCursorPosition(userY, userX);
            //    Console.Write('@');
            //    ConsoleKeyInfo charKey = Console.ReadKey();
            //    switch (charKey.Key)
            //    {
            //        case ConsoleKey.UpArrow:
            //            if (map[userX - 1, userY] != '#')
            //            {
            //                userX--;
            //            }
            //            break;
            //        case ConsoleKey.DownArrow:
            //            if (map[userX + 1, userY] != '#')
            //            {
            //                userX++;
            //            }
            //            break;
            //        case ConsoleKey.LeftArrow:
            //            if (map[userX, userY - 1] != '#')
            //            {
            //                userY--;
            //            }
            //            break; 
            //        case ConsoleKey.RightArrow:
            //            if (map[userX, userY + 1] != '#')
            //            {
            //                userY++;
            //            }
            //            break;
            //    }
            //    Console.ReadKey();
            //    Console.Clear();
            //}
        }
    }
    class Table
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlaces;
        public Table(int Number, int MaxPlaces)
        {
            this.Number = Number;
            this.MaxPlaces = MaxPlaces;
            FreePlaces = MaxPlaces;
        }
        public Table()
        {
            Number = 0;
            MaxPlaces = 0;
            FreePlaces = 0;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Число свободных мест у стола {Number}: {FreePlaces} из {MaxPlaces}");
        }
        public void ReserveTable(int NumPlacesReserve)
        {
            if (FreePlaces >= NumPlacesReserve)
            {
                FreePlaces -= NumPlacesReserve;
                Console.WriteLine($"Получилось забронировать: {NumPlacesReserve} на {Number}");
            }
            else
            {
                Console.WriteLine("Не получилось забронировать, мест мало");
            }
        }
    }
}
