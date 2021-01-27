using System;

namespace Project_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            for (int i = userInput.Length; i > 0; i--)
            {
                Console.Write(userInput[i-1]);
            }
            Console.ReadKey();
        }
    }
}
