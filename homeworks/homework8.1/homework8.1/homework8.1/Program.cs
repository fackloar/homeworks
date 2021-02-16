using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleApp;

namespace homework8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting.SayHello();
            if (string.IsNullOrEmpty(Properties.Settings.Default.userName))
            {

                Console.WriteLine("Enter user name:");
                Properties.Settings.Default.userName = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.Job))
            {

                Console.WriteLine("What is your job?");
                Properties.Settings.Default.Job = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.Age))
            {

                Console.WriteLine("How old are you?");
                Properties.Settings.Default.Age = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            string userName = Properties.Settings.Default.userName;
            string job = Properties.Settings.Default.Job;
            string age = Properties.Settings.Default.Age;
            string greeting = Properties.Settings.Default.Greeting;
            Console.WriteLine($"{greeting}, {userName}!\nYour job is {job}. You are {age} years old");
            Console.ReadKey();
        }
    }
}
