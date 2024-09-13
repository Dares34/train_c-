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

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User.Identificators = 10;
            User user1 = new User();
            User user2 = new User();
            Console.WriteLine(user1.ShowInfo());
            Console.WriteLine(user2.ShowInfo());

        }

    }
    class User
    {
        public static int Identificators;
        private int _identificator;
        public User() {
            _identificator = ++Identificators;
        }
        public int ShowInfo()
        {
            return _identificator;
        }
    }
   
}
