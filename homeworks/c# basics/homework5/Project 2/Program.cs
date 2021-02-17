using System;
using System.IO;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "startup.txt";
            Console.WriteLine("Hello! I will now add current time to startup.txt!");
            DateTime datetime = DateTime.Now;
            string time = datetime.ToString();
            File.AppendAllText(filename, time);
            Console.ReadKey();
        }
    }
}
