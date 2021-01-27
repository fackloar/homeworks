using System;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] phonebook = new string[5,2] { {"Roman", "fackloar@gmail.com"}, {"Kate", "KateP@gmail.com"}, {"John", "John.Toolz@gmail.com"}, 
            {"Bill", "Billedwards@gmail.com"}, {"Vika", "Victoryforever@gmail.com"} };
            for (int i = 0; i < phonebook.GetLength(0); i++)
            {
                for (int j = 0; j < phonebook.GetLength(1); j++)
                {
                    Console.Write($"{phonebook[i,j]}  ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
