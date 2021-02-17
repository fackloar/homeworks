using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace Project_5
{
    class Program
    {

        public class ToDo 
        {
            //public field
            public string Title { get; set; }

            public bool isDone { get; set; }

            public ToDo(string name, bool status)
            {
                Title = name;
                isDone = status;
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This is a ToDo list.");
            choice:
            Console.WriteLine("Choose one:");
            Console.WriteLine("1: add new things to your ToDo list");
            Console.WriteLine("2: check and edit what you already have on the list");
            Console.WriteLine("q: exit the program");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Let's add some tasks! First, write the name of your new task");
                string userNameTask = Console.ReadLine();
                Console.WriteLine("Now, input 'false' if you HAVEN'T DONE it and 'true' if you HAVE already DONE it.");
                string userStatusTask = Console.ReadLine();
                bool userStatusBool = Convert.ToBoolean(userStatusTask);
                ToDo task = new ToDo(userNameTask, userStatusBool);
                string json = JsonSerializer.Serialize(task);
                File.AppendAllText("goals.json", json);
                Console.WriteLine("Great! Now let's go back to the main menu.");
                Console.ReadKey();
                Console.Clear();
                goto choice;
                
            }
            else if (choice == "2")
            {
                Console.WriteLine("Let's see what goals you have:");
                string json = File.ReadAllText("goals.json");
                var tasks = JsonSerializer.Deserialize<ToDo>(json);
                

            }
            else if (choice == "q")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please input '1' or '2' or 'q' to exit");
                goto choice;
            }
            Console.ReadKey(); 
        }
    }
}
