using System;

namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's generate a check for you!");
            Console.WriteLine("What was the name of the shop?");
            string name = Console.ReadLine();
           Console.WriteLine("What was the date and time (if known) of the purchase?");
            Console.WriteLine("Please only write numbers and/or name of the month.");
            string userDate = Console.ReadLine();
            var parsedDate = DateTime.Parse(userDate);
            Console.WriteLine("How many things were bought?");
            string numberOfPurchases = Console.ReadLine();
            int parsedNumber = Int32.Parse(numberOfPurchases);
            int sum = 0;
            for (int i = 1; i <= parsedNumber; i++)
            {
                Console.WriteLine($"What was the price of the thing number {i}?");
                string price = Console.ReadLine();
                int parsedPrice = Int32.Parse(price);
                sum = sum + parsedPrice;
            }
            Console.WriteLine(".-.---------------------------------.-.");
            Console.WriteLine($"((o))          {name}               )");
            Console.WriteLine("'\'U/_______          _____         ____/");
            Console.WriteLine("|                                  |");
            Console.WriteLine($"|               {parsedDate}|");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine($"|You bought {parsedNumber} things                |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|____    _______    __  ____    ___|KCK");
            Console.WriteLine("/'A''\'                                  ");
            Console.WriteLine($"((o))               Sum: {sum}          )");
            Console.WriteLine("'-'----------------------------------'");
            Console.ReadKey(); 

        }
    }
}
