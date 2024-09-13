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
            //Vector2 targetPosition = new Vector2(10, 10);
            //Vector2 playerPosition = targetPosition;
            //playerPosition.X += 15;
            //Console.WriteLine(targetPosition.X);
            ObjectBullet bullet = new ObjectBullet();
            
            Vector2 newPosition = new Vector2();
            newPosition.X = 50;
            bullet.Position = newPosition;

            bullet.Position.ShowInfo();
        }

    }
    class ObjectBullet
    {
        public Vector2 Position;

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

        public void ShowInfo()
        {
            Console.WriteLine($"координата x:{X} y:{Y}");
        }
    }
}
