using System;

namespace Project_2
{
    class Program
    {

        static int getNumbers(string[] data)
        {
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                Int32.TryParse(data[i], out int temp);
                   sum = sum + temp;
            }
            return sum; 
        }
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any numbers divided by space and we'll count their sum");
            string input = Console.ReadLine();
            string[] inputString = input.Split(" ");
            Console.WriteLine($"The sum is: {getNumbers(inputString)}");
            Console.ReadKey();
        }
    }
}
