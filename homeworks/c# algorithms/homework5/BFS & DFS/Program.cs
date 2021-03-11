using System;
using System.Collections.Generic;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TreeNode> list = new List<TreeNode>();
            int[][] testTrees = new int[][] 
            {
                new int[] { 10, 7, 9, 12, 6, 14, 3, 11, 4 }, 
                new int[] { 35, 43, 12, 13, 1, 45, 99, 143, 24 }, 
                new int[] { 100, 200, 50, 25, 400, 800, 12, 6, 1600, 3200 } 
            };
            int[] testSearchValues = { 10, 45, 3200 };
            string[] expectedOutput = new string[] { "BFS: \n10 7 12 6 9 11 14 3 4\nDFS: \n10 7 6 3 4 9 11 12 14", 
                                                     "BFS: \n35 12 43 1 13 45 24 99 143\nDFS: \n35 12 1 13 24 43 45 99 143", 
                                                     "BFS: \n100 50 200 25 400 12 800 6 1600 3200\nDFS: \n100 50 25 12 6 200 400 800 1600 3200" };
            for (int i = 0; i < testTrees.Length; i++)
            {
                var Tree = new TreeNode(i);
                for (int j = 0; j<testTrees[i].Length; j++ )
                {
                    Tree.AddItem(testTrees[i][j]);
                }
                list.Add(Tree);
            }
            int count = 0;
            foreach (TreeNode t in list)
            {
                t.PrintTree();
                BFS(t, testSearchValues[count]);
                DFS(t, testSearchValues[count]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine($"Expected Output:\n{expectedOutput[count]}");
                count++;
                Console.ResetColor();
            }
            
        }
        public static void BFS(TreeNode Tree, int value)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Looking for node with value {value} using BFS:");
            Queue<TreeNode> Nodes = new Queue<TreeNode>();
            Nodes.Enqueue(Tree.GetRoot());
            while (Nodes.Count > 0)
            {
                TreeNode current = Nodes.Dequeue();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{current.Value} ");
                {
                    if (current == Tree.GetNodeByValue(value))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"(<== Found it!) ");
                    }
                    if (current.LeftChild != null)
                        Nodes.Enqueue(current.LeftChild);
                    if (current.RightChild != null)
                        Nodes.Enqueue(current.RightChild);
                }
                
            }
            Console.ResetColor(); 
        }

        public static void DFS(TreeNode Tree, int value)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Looking for node with value {value} using DFS:");
            Stack<TreeNode> Nodes = new Stack<TreeNode>();
            Nodes.Push(Tree.GetRoot());
            while (Nodes.Count > 0)
            {
                TreeNode current = Nodes.Pop();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{current.Value} ");
                if (current == Tree.GetNodeByValue(value))
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"(<== Found it!) ");
                }
                if (current.RightChild != null)
                    Nodes.Push(current.RightChild);
                if (current.LeftChild != null)
                    Nodes.Push(current.LeftChild);
                
            }
            Console.ResetColor();
        }
    }
}