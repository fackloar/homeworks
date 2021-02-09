using System;
using System.Diagnostics;

namespace TaskManager
{
    class Program
    {
        public enum ErrorCodes
        {
        NoProcessFound
        }

        public class NameException : Exception
        {
            public NameException(ErrorCodes code)
            {
                Code = code;
            }

            public ErrorCodes Code { get; }
        }

        static public void GetProcessList()
        {
            System.Diagnostics.Process[] curProcesses = Process.GetProcesses();
            for (int i = 0; i < curProcesses.GetLength(0); i++)
            {
                Console.WriteLine(curProcesses[i]);
                Console.WriteLine($"        ID: {curProcesses[i].Id.ToString()}");
            }
        }
        static public void KillProcess()
        {
            Console.WriteLine("Now you can end any process. \nWrite its name or its ID.\nNote that if you end process by its name it will end ALL process of the same name!");
            input:
            string userInput = Console.ReadLine();
            bool chars = Int32.TryParse(userInput, out int id);
                
                if (chars != true)
                {
                    try 
                    {
                        Process[] processToKill = Process.GetProcessesByName(userInput);
                        if (processToKill == null || processToKill.Length == 0)
                        {
                            throw new NameException(ErrorCodes.NoProcessFound);
                        }
                        else
                        {
                            for (int i = 0; i < processToKill.GetLength(0); i++)
                            processToKill[i].Kill();
                            Console.WriteLine($"All processes by the name {userInput} are succesfully ended");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Something wrong with your input.\nWrite name or ID.");
                        goto input;
                    }
                }
                else if (chars)
                {
                    Process processToKill = Process.GetProcessById(id);
                    processToKill.Kill();
                    Console.WriteLine($"All processes by ID: {id} succesfully ended");
                    }
        }

        static public void userChoice()
        {
            choice:
            Console.WriteLine("Input 1 to get updated list of processes.\nInput 2 to end a process.\nInput 'q' to quit.");
            string userChoice = Console.ReadLine();
            if (userChoice == "q")
            {
                Process ThisApp = Process.GetCurrentProcess();
                ThisApp.Kill();
            }
            bool inputNumbers = Int32.TryParse(userChoice, out int option);
            if (option == 1)
            {
                GetProcessList();
                goto choice;
            }
            else if (option == 2)
            {
                KillProcess();
                goto choice;
            }
            else
            {
                Console.WriteLine("Something wrong with your input.");
                goto choice;
            }
        }
            

        static void Main(string[] args)
        {
            Console.WriteLine("This is the Task Manager.\nYou will see all the processes running on the computer and their ID.");
            GetProcessList();
            userChoice();
            
        }
    }
}
