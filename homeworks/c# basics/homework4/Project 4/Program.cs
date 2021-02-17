using System;

namespace Project_4
{
    class Program
    {
        
    static int Fibonacci(int n)
    {
        if (n == 0 || n == 1)
        {
            return n;
        }
        else if (n < 0)
        {
            return Fibonacci(n+2) - Fibonacci(n+1);
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Let's find Fibonacci number for the number you want!");
            Console.WriteLine("Write any number please");
            start:
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int n) == false)
            {
                Console.WriteLine("Error: please write a number!");
                goto start;
            }
            Console.WriteLine($"Your Fibonacci number is {Fibonacci(n)}");
            Console.ReadKey();

        }
    }
}
