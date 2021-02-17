using System;

namespace project3
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserInputNum = "null";
                Start:
                Console.WriteLine("Let's check if it's and even number or an odd one!");
                Console.WriteLine("Write any number. Write 'q' to quit.");
                UserInputNum = Console.ReadLine();
                if (UserInputNum == "q")
                {
                    return;
                }
                else
                {
                    int numConverted = Convert.ToInt32(UserInputNum);
                    int remainder = numConverted % 2; 
                    if (remainder == 0)
                    {
                        Console.WriteLine("It's an even number!");
                    }
                    else
                    {
                        Console.WriteLine("It's an odd number!");
                    }
                    goto Start;
                }
        
        }
    }
    
    }
