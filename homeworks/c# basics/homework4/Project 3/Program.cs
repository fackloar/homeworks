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
        enum Seasons
        {
            Winter = 1,
            Spring,
            Summer,
            Autumn
        }
        static int GetSeason(int number)
        {
            var season = (Seasons) 1;
            if (number == 12 || number == 1 || number == 2)
            {
                season = (Seasons) 1;
            }
            else if (number == 3 || number == 4 || number == 5)
            {
                season = (Seasons) 2;
            }
            else if (number == 6 || number == 7 || number == 8)
            {
                season = (Seasons) 3;
            }
            else if (number == 9 || number == 10 || number == 11)
            {
                season = (Seasons) 4;
            }
            int seasonNumber = Convert.ToInt32(season);
            return seasonNumber;
            
        }

        static string writeSeason(int number)
        {
            string seasonName = null; 
            switch (number)
            {
                case 1: 
                    seasonName = "Winter";
                    break;
                case 2:
                    seasonName = "Spring";
                    break;
                case 3:
                    seasonName = "Summer";
                    break;
                case 4:
                    seasonName = "Autumn";
                    break;
            }
            return seasonName;
        }





        static void Main(string[] args)
        {
            
            Console.WriteLine("What is the number of the current month?");
            start:
            string currentMonth = Console.ReadLine();
            if (Int32.TryParse(currentMonth, out int currentMonthNumber) == false)
            {
                Console.WriteLine("Error: Write a number, please");
                goto start;
            } 
            currentMonthNumber = Convert.ToInt32(currentMonth);
            if (currentMonthNumber > 12 || currentMonthNumber <= 0)
            {
                Console.WriteLine("Error: Write a number from 1 to 12 please");
                goto start;
            }
            Console.WriteLine($"It's {writeSeason(GetSeason(currentMonthNumber))}");
            Console.ReadKey();
        }
    }
}