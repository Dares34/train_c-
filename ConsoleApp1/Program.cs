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
            Vehicle[] vehicles = { new Car(), new Train() };
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.Move();
            }
        }

    }
    
    abstract class Vehicle
    {
        protected float Speed;
        public abstract void Move();
        public float GetCurrentSpeed()
        {
            return Speed;
        }
    }
    class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Машина едет по асфальту");
        }
    }
    class Train : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Трактор прётся");
        }
    }
}
