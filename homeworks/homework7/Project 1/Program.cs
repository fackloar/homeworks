using System;

namespace Project_1
{
    class Program
    {
     
        static public bool EqualSlices(int totalSlices, int peopleNumber, int slicesEach)
        {
            bool equalSlices = true;
            int slicesGot = peopleNumber * slicesEach;
            if (totalSlices >= slicesGot)
            {
                equalSlices = true;
            }
            else if (totalSlices < slicesGot)
            {
                equalSlices = false;
            }
            else if (peopleNumber == 0)
            {
                equalSlices = true;
            }
            return equalSlices; 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Let's see if it's possible to divide a pie evenly!");
            Console.WriteLine("Input how many slices you have in total.");
            string totalSlices = Console.ReadLine();
            int totalSlicesInt = Int32.Parse(totalSlices);
            Console.WriteLine("Input how many people will eat the pie.");
            string peopleNumber = Console.ReadLine();
            int peopleNumberInt = Int32.Parse(peopleNumber);
            Console.WriteLine("Input how many slices should each person get.");
            string slicesEach = Console.ReadLine();
            int slicesEachInt = Int32.Parse(slicesEach);
            bool answer = EqualSlices(totalSlicesInt, peopleNumberInt, slicesEachInt);
            if (answer == true)
            {
                Console.WriteLine("You can divide a pie evenly!");
            }
            else
            {
                Console.WriteLine("You can't divide a slice evenly");
            }
            Console.ReadKey();
        }
    }
}
