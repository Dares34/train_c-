﻿using System;
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
            Behavior[] behaviors = {
                new Walker(),
                new Jumper()
            };
            while (true)
            {
                foreach (var behavior in behaviors)
                {
                    behavior.Update();
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

    }
    class Behavior
    {
        public virtual void Update()
        {

        }

    }
    class Walker : Behavior
    {
        public override void Update()
        {
            Console.WriteLine("Иду");
        }
    }
    class Jumper : Behavior
    {
        public override void Update()
        {
            Console.WriteLine("Прыгаю");
        }
    }

}
