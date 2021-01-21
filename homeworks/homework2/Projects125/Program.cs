using System;

namespace projects125
{
    class Program
    {
        enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        } 
        static void Main(string[] args)
        {
            Console.WriteLine("What is the number of the current month?");
            string currentMonth = Console.ReadLine();
            int currentMonthNumber = Convert.ToInt32(currentMonth);
            switch (currentMonthNumber)
            {
                case 1: 
                    Console.WriteLine($"It's {Months.January}");
                    break;
                case 2: 
                    Console.WriteLine($"It's {Months.February}");
                    break;
                case 3:
                    Console.WriteLine($"It's {Months.March}");
                    break;
                case 4:
                    Console.WriteLine($"It's {Months.April}");
                    break;
                case 5:
                    Console.WriteLine($"It's {Months.May}");
                    break;
                case 6:
                    Console.WriteLine($"It's {Months.June}");
                    break;
                case 7:
                    Console.WriteLine($"It's {Months.July}");
                    break;
                case 8: 
                    Console.WriteLine($"It's {Months.August}");
                    break;
                case 9:
                    Console.WriteLine($"It's {Months.September}");
                    break;
                case 10:
                    Console.WriteLine($"It's {Months.October}");
                    break;
                case 11:
                    Console.WriteLine($"It's {Months.November}");
                    break;
                case 12:
                    Console.WriteLine($"It's {Months.December}");
                    break;
            }
            Console.WriteLine("What was the maximum temperature today?");
            string maxt = Console.ReadLine();
            int maxtn = Convert.ToInt32(maxt);
            Console.WriteLine("What was the minimum temperature today?");
            string mint = Console.ReadLine();
            int mintn = Convert.ToInt32(mint);
            int avg = (maxtn + mintn) / 2; 
            Console.WriteLine($"Average temperature is {avg} Celsius");
            if ((currentMonthNumber == 12 || currentMonthNumber == 1 || currentMonthNumber == 2) && avg > 0)
            {
                Console.WriteLine("It's a rainy winter!");
            }
            Console.ReadKey();
        }
    }
}
