using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.IO;
using System.ComponentModel;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = {
                new Task(new Performer("Артем"), "Выкопать яму."),
                new Task(new Performer("Серега"), "Сделать подкоп")
            };
            Board schedule = new Board(tasks);
            schedule.ShowAllTasks();

        }
    }
    class Performer
    {
        public string Name;
        public Performer(string name)
        {
            Name = name;
        }
    }
    class Board
    {
        public Task[] Tasks;
        public Board(Task[] tasks)
        {
            Tasks = tasks;
        }
        public void ShowAllTasks()
        {
            for (int i = 0;i < Tasks.Length; i++)
            {
                Tasks[i].ShowInfo();
            }
        }
    }
    class Task
    {
        public Performer Worker;
        public string Description;

        public Task(Performer worker, string description)
        {
            Worker = worker;
            Description = description;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Ответственный: {Worker.Name}\n" +
                $"Описание задачи: {Description}");
        }
    }
}
