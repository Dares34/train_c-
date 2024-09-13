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
            
        }

    }
    interface IMovable
    {
        void Move();
    }
    interface IBurnable
    {
        void Burn();
    }
    class Vehicle
    {
        
    }
    class Car : Vehicle, IMovable, IBurnable
    {
        public void Move()
        {

        }
        public void Burn()
        {

        }
    }
}
