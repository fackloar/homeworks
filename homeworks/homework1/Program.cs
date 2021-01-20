using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}! Today is {DateTime.Today}");
            Console.ReadKey();
        }
    }
}
