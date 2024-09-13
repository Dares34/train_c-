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
            //Vector2 position = default(Vector2);
            Vector2 po = new Vector2(10);
            Console.WriteLine( po.X);
            //position.X = 10;
        }

    }
    struct Vector2
    {
        public int X, Y;
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Vector2(int x) : this()
        {
            X = x;
        }
    }
}
