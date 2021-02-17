using System;
using System.IO;
using System.Text;

namespace Project_4
{
    class Program
    {
        static void Recurrsion() // вариант с рекурсией
        {
            Console.WriteLine("Hello! I will create a .txt file and save a path to it inside.");
            var filename = File.Create("text.txt");
            filename.Close();
            var path = Directory.GetCurrentDirectory();
            string[] text = Directory.GetFiles(path, "text.txt");
            File.AppendAllText(text[0], path);
            string[] fileList = Directory.GetFiles(path);
            string[] directoryList = Directory.GetDirectories(path);
            DirSearch(path);
            File.AppendAllLines(text[0], fileList);
            File.AppendAllLines(text[0], directoryList);
            Console.WriteLine("The file is created!");

            void DirSearch(string sDir)
            {
                try
                {
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        foreach (string f in Directory.GetFiles(d))
                        {
                            File.AppendAllText(text[0], f);
                            File.AppendAllText(text[0], Environment.NewLine);
                        }
                        DirSearch(d);
                    }
                }
                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
            }
        }
        
        
        static void NoRecursion() //Вариант без рекурсии
        {
            Console.WriteLine("Hello! I will create a .txt file and save a path to it inside.");
            var filename = File.Create("text.txt");
            filename.Close();
            var path = Directory.GetCurrentDirectory();
            string[] allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (string file in allFiles)
            {
                File.AppendAllText("text.txt", file);
                File.AppendAllText("text.txt", Environment.NewLine);
            }
            Console.WriteLine("The file is created!");
        }
        
        
        
        
        static void Main(string[] args)
        {
            choice:
            Console.WriteLine("This program works in two ways: write 1 or 2 to choose one of them.");
            Console.WriteLine("1 is for option without recursion and 2 - with");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                NoRecursion();
            }
            else if (choice == "2")
            {
                Recurrsion();
            }
            else 
            {
                Console.WriteLine("Error: please input 1 or 2");
                goto choice;
            }
            Console.ReadKey();
        }
    }
}
