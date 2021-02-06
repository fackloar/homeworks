using System;
using System.IO;


namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "text.txt";
            Console.WriteLine("Write anything and we will save it into a .txt file!");
            string userInput = Console.ReadLine();
            File.WriteAllText(filename, userInput);
            Console.WriteLine("The file is created!");
            Console.ReadKey();
        }
    }
}
