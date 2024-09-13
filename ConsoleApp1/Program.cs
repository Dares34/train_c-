using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.IO;
using System.ComponentModel;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClub pcClub = new ComputerClub(10);
            pcClub.Work();
        }

    }

    class ComputerClub
    {
        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();

        public ComputerClub(int computersCount)
        {
            Random rnd = new Random();
            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(rnd.Next(5, 15)));
            }
            CreateNewQlients(25, rnd);
        }
        public void CreateNewQlients(int count, Random random)
        {
            for (int i = 0; i < count; i++)
            {
                _clients.Enqueue(new Client(random.Next(100, 251), random));
            }
        }

        public void Work()
        {
            while (_clients.Count > 0)
            {
                Client newClient = _clients.Dequeue();
                Console.WriteLine($"Баланс комп клуба {_money} руб.");
                Console.WriteLine($"У вас новый клиент и он хочет купить {newClient.DesiredMinutes} минут");
                Console.WriteLine($"Клиентов в очереди {_clients.Count}");
                ShowAllComputesState();
                Console.WriteLine("\nВы предлагает ему компьютер под номером: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int computerNumber))
                {
                    computerNumber -= 1;
                    if (computerNumber >= 0 && computerNumber < _computers.Count){
                        if (_computers[computerNumber].IsTaken)
                        {
                            Console.WriteLine("Этот компьютер уже занят, клиент ушёл");
                        }
                        else
                        {
                            if (newClient.CheckSolvency(_computers[computerNumber]))
                            {
                                Console.WriteLine("Клиент оплатил место и сел за комп " + (computerNumber + 1));
                                _money += newClient.Pay();
                                _computers[computerNumber].BecomeTaken(newClient);
                            }
                            else
                            {
                                Console.WriteLine("У клиента недостаточно денег");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого компьютера нет. Клиент ушёл.");
                    }
                }
                else
                {
                    CreateNewQlients(1, new Random());
                    Console.WriteLine("неверный ввод для компьютера");
                }

                Console.WriteLine(
                    "Чтобы обслужить следующего клиента " +
                    "нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                SpendOneMinute();
            }
        }

        public void ShowAllComputesState()
        {
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                _computers[i].ShowState();
            }
        }
        private void SpendOneMinute()
        {
            foreach (var computer in _computers)
            {
                computer.SpendOneMinute();
            }
        }
    }
    class Computer
    {
        private Client _client;
        private int _minuteRemaining;
        public bool IsTaken
        {
            get
            {
                return _minuteRemaining > 0;
            }
        }
        public int PricePerMinute { get; private set; }

        public Computer(int pricePerMinute)
        {
            PricePerMinute = pricePerMinute;

        }

        public void BecomeTaken(Client client)
        {
            _client = client;
            _minuteRemaining = _client.DesiredMinutes;
        }
        public void BecomeEmpty()
        {
            _client = null;
        }
        public void SpendOneMinute()
        {
            _minuteRemaining--;
        }

        public void ShowState()
        {
            if (IsTaken)
            {
                Console.WriteLine($"Компьютер занят, осталось минут {_minuteRemaining}");
            }
            else
            {
                Console.WriteLine($"Компьютер свободен, цена за минуту: {PricePerMinute}");
            }
        }

    }
    class Client
    {
        private int _money;
        private int _moneyToPay;
        public int DesiredMinutes { get; private set; }

        public Client(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(10, 30);
        }

        public void TakeMoney(int minutePrice)
        {
            _money -= minutePrice;
        }

        public bool CheckSolvency(Computer computer)
        {
            _moneyToPay = DesiredMinutes * computer.PricePerMinute;
            if (_money >= _moneyToPay)
                return true;
            else
            {
                _moneyToPay = 0;
                return false;
            }

        }
        public int Pay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}
