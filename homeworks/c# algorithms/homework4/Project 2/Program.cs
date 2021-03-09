using System;
using System.Collections.Generic;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Start program or test?\n1:Start\n2:Test");
            var userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.D1)
            {
                UserInputMode();
            }
            else if (userInput.Key == ConsoleKey.D2)
            {
                TestMode();
            }
            else
            {
                Console.WriteLine("Wrong input!");
                goto Start;
            }

        }

        public static void TestMethod(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int valueDel1, int valueDel2, int valueDel3)
        {
            var TreeNode = new TreeNode(0);
            TreeNode.AddItem(value1);
            TreeNode.AddItem(value2);
            TreeNode.AddItem(value3);
            TreeNode.AddItem(value4);
            TreeNode.AddItem(value5);
            TreeNode.AddItem(value6);
            TreeNode.AddItem(value7);
            TreeNode.AddItem(value8);
            TreeNode.AddItem(value9);
            TreeNode.AddItem(value10);
            TreeNode.AddItem(value11);
            TreeNode.RemoveItem(valueDel1);
            TreeNode.RemoveItem(valueDel2);
            TreeNode.RemoveItem(valueDel3);
            TreeNode.PrintTree();
        }

        public static void UserInputMode()
        {
            Console.WriteLine("Hello! This program build a binary tree and lets you interact with it.");
            var TreeNode = new TreeNode(0);
            TreeNode.AddItem(10);
            TreeNode.AddItem(7);
            TreeNode.AddItem(9);
            TreeNode.AddItem(12);
            TreeNode.AddItem(6);
            TreeNode.AddItem(14);
            TreeNode.AddItem(3);
            TreeNode.AddItem(11);
            TreeNode.AddItem(4);
            TreeNode.PrintTree();
        UserStart:
            Console.WriteLine("1: Add a number to a tree");
            Console.WriteLine("2: Add a random number to a tree");
            Console.WriteLine("3: Remove a number");
            Console.WriteLine("q: Exit");
            var userInput = Console.ReadKey();
            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("What number do you want to add?");
                    int userNum = Convert.ToInt32(Console.ReadLine());
                    TreeNode.AddItem(userNum);
                    Console.WriteLine($"Adding {userNum} to the tree... Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    TreeNode.PrintTree();
                    goto UserStart;
                case ConsoleKey.D2:
                    var rand = new Random();
                    int randInt = rand.Next();
                    Console.WriteLine($"Adding {randInt} to the tree... Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    TreeNode.PrintTree();
                    goto UserStart;
                case ConsoleKey.D3:
                    Console.WriteLine("What number do you want to add?");
                    userNum = Convert.ToInt32(Console.ReadLine());
                    TreeNode.RemoveItem(userNum);
                    Console.WriteLine($"Removing {userNum} from the tree... Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    TreeNode.PrintTree();
                    goto UserStart;
                case ConsoleKey.Q:
                    Environment.Exit(1);
                    break;
            }
        }

        public static void TestMode()
        {
            Console.WriteLine("Tree:");
            TestMethod(10,20,30,5,4,2,50,60,70,65,80,20,2,10);
            Console.WriteLine("Expected:\n5\n4 30\n   50\n     60\n     70\n   65    80");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tree:");
            TestMethod(123, 256, 180, 90, 70, 79, 300, 144, 567,999, 435, 70, 300, 144);
            Console.WriteLine("Expected:\n123\n90  256\n79  180  567\n        435     999");
            TestMethod(10,8,12,9,11,6,14,7,13,15,3,10,8,3);
            Console.WriteLine("Expected:\n9\n6        12\n7      11    14\n         13    15");
        }
    }
}