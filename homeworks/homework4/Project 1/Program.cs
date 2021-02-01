using System;

namespace Project_1
{
    class Program
    {

       /* static string GetFullName(string firstName, string lastName, string patronymic)
        {
            string fullName = firstName + " " + patronymic + " " + lastName;
            return fullName;


        } */ // закоментировал вариант без params 

        static string GetFullName(params string[] names)
        {
            string fullName = null;
            string Error = "Error: incorrect number of params";
            int i = 0;
            for (i = 0; i < names.Length; i++)
                fullName += $"{names[i]} ";
            if (i == 3)
            {
                fullName = $"{names[0]} {names[2]} {names[1]}";
                return fullName;
            }
            else
            return Error;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"Hello, {GetFullName("John", "Doe", "William")}");
            Console.WriteLine($"Hello, {GetFullName("Eva", "Green", "The Great")}");
            Console.WriteLine($"Hello, {GetFullName("Anton", "Chekhov", "Pavlovich")}");
            Console.WriteLine($"Hello, {GetFullName("Denis", "Korobov", "Ivanovich", "lox")}");
            Console.ReadKey();
        }
    }
}
