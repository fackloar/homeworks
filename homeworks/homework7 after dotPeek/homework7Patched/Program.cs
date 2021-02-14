// Decompiled with JetBrains decompiler
// Type: Project_1.Program
// Assembly: homework7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3CD4C739-EAE6-40B3-9719-AE63992029D2
// Assembly location: C:\Users\Roman\Desktop\geekbrains\c#\homeworks\homework7 VS remade\homework7\homework7\bin\Debug\netcoreapp3.1\homework7.dll

using System;

namespace Project_1
{
    internal class Program
    {
        public static bool EqualSlices(int totalSlices, int peopleNumber, int slicesEach)
        {
            bool flag = true;
            int num = peopleNumber * slicesEach;
            if (totalSlices >= num)
                flag = true;
            else if (totalSlices < num)
                flag = false;
            else if (peopleNumber == 0)
                flag = true;
            return flag;
        }

        private static void Main(string[] args)
        {
        start:
            Console.WriteLine("Let's see if it's possible to divide a pie evenly!");
            Console.WriteLine("Input how many slices you have in total.");
            int totalSlices = int.Parse(Console.ReadLine());
            Console.WriteLine("Input how many people will eat the pie.");
            int peopleNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Input how many slices should each person get.");
            int slicesEach = int.Parse(Console.ReadLine());
            if (Program.EqualSlices(totalSlices, peopleNumber, slicesEach))
                Console.WriteLine("You can divide a pie evenly!");
            else
                Console.WriteLine("You can't divide a slice evenly");
            Console.WriteLine("Press any key to start again, 'q' to quit.");
            while (Console.ReadKey().Key != ConsoleKey.Q)
                goto start;
        }
    }
}
