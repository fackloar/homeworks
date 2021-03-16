using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph_BFS_DFS
{
    public class Node //Вершина
    {
        public bool Visited { get; set; }
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи
    }

    public class Edge //Ребро
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } // узел, на который связь ссылается
    }

    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Test1();
            //Test2();
            Test3();

            Console.ReadLine();

        }

        public static void Test1()
        { 
            var NodeA = new Node()
            {
                Value = 10,
                Edges = new List<Edge>(),
            };

            var NodeB = new Node()
            {
                Value = 20,
                Edges = new List<Edge>()
            };
            var NodeC = new Node()
            {
                Value = 30,
                Edges = new List<Edge>()
            };
            var NodeD = new Node()
            {
                Value = 40,
                Edges = new List<Edge>()
            };
            var NodeE = new Node()
            {
                Value = 50,
                Edges = new List<Edge>()
            };
            var NodeF = new Node()
            {
                Value = 60,
                Edges = new List<Edge>()
            };
            AddEdge(NodeA, NodeB, 4);
            AddEdge(NodeA, NodeE, 1);
            AddEdge(NodeB, NodeC, 6);
            AddEdge(NodeB, NodeF, 10);
            AddEdge(NodeC, NodeD, 8);
            AddEdge(NodeC, NodeF, 7);
            AddEdge(NodeD, NodeE, 2);
            AddEdge(NodeE, NodeF, 3);
            DFS(NodeA, 10);
            Console.WriteLine("\nExpected output: \n===> (10) ===4===> (20) ===6===> (30) ===8===> (40) ===2===> (50) ===3===> (60) ===10===> (going to 50 and) STOP");
            ClearVisited(NodeA);
            BFS(NodeA, 10);
            Console.WriteLine("\nExpected output: \n10 20 50 30 60 40");
        }

        public static void Test2()
        {
            var NodeA = new Node()
            {
                Value = 1,
                Edges = new List<Edge>(),
            };

            var NodeB = new Node()
            {
                Value = 2,
                Edges = new List<Edge>()
            };
            var NodeC = new Node()
            {
                Value = 3,
                Edges = new List<Edge>()
            };
            var NodeD = new Node()
            {
                Value = 4,
                Edges = new List<Edge>()
            };
            var NodeE = new Node()
            {
                Value = 5,
                Edges = new List<Edge>()
            };
            var NodeF = new Node()
            {
                Value = 6,
                Edges = new List<Edge>()
            };
            var NodeG = new Node()
            {
                Value = 7,
                Edges = new List<Edge>()
            };
            var NodeH = new Node()
            {
                Value = 8,
                Edges = new List<Edge>()
            };
            var NodeI = new Node()
            {
                Value = 9,
                Edges = new List<Edge>()
            };
            AddEdge(NodeA, NodeB, 2);
            AddEdge(NodeB, NodeC, 4);
            AddEdge(NodeC, NodeD, 1);
            AddEdge(NodeD, NodeE, 1);
            AddEdge(NodeE, NodeF, 2);
            AddEdge(NodeF, NodeG, 1);
            AddEdge(NodeG, NodeH, 4);
            AddEdge(NodeH, NodeA, 2);
            AddEdge(NodeH, NodeI, 3);
            AddEdge(NodeI, NodeB, 3);
            DFS(NodeA, 1);
            Console.WriteLine("\nExpected output: \n===> (1) ===2===> (2) ===4===> (3) ===1===> (4) ===1===> (5) ===2===> (6) ===1===> (7) ===4===> (8) ===3===> (9) ======> STOP");
            ClearVisited(NodeA);
            BFS(NodeA, 1);
            Console.WriteLine("\nExpected output: \n1 2 8 3 9 7 4 6 5");
        }

        public static void Test3()
        {


            var NodeA = new Node()
            {
                Value = 1,
                Edges = new List<Edge>(),
            };

            var NodeB = new Node()
            {
                Value = 2,
                Edges = new List<Edge>()
            };
            var NodeC = new Node()
            {
                Value = 3,
                Edges = new List<Edge>()
            };
            var NodeD = new Node()
            {
                Value = 4,
                Edges = new List<Edge>()
            };
            var NodeE = new Node()
            {
                Value = 5,
                Edges = new List<Edge>()
            };
            var NodeF = new Node()
            {
                Value = 6,
                Edges = new List<Edge>()
            };
            var NodeG = new Node()
            {
                Value = 7,
                Edges = new List<Edge>()
            };
            var NodeH = new Node()
            {
                Value = 8,
                Edges = new List<Edge>()
            };
            var NodeI = new Node()
            {
                Value = 9,
                Edges = new List<Edge>()
            };
            var NodeJ = new Node()
            {
                Value = 10,
                Edges = new List<Edge>()
            };
            AddEdge(NodeA, NodeB, 1);
            AddEdge(NodeB, NodeD, 2);
            AddEdge(NodeD, NodeG, 3);
            AddEdge(NodeG, NodeE, 4);
            AddEdge(NodeE, NodeC, 5);
            AddEdge(NodeC, NodeA, 1);
            AddEdge(NodeC, NodeF, 6);
            AddEdge(NodeF, NodeE, 5);
            AddEdge(NodeE, NodeH, 7);
            AddEdge(NodeH, NodeI, 8);
            AddEdge(NodeI, NodeJ, 10);
            AddEdge(NodeJ, NodeH, 9);
            DFS(NodeA, 1);
            Console.WriteLine("\nExpected output: \n===> (1) ===1===> (2) ===2===> (4) ===3===> (7) ===4===> (5) ===5===> (3) ===6===> (6) ===7===> (8) ===8===> (9) ===10===> (10)");
            ClearVisited(NodeA);
            BFS(NodeA, 10);
            Console.WriteLine("\nExpected output: \n1 2 3 4 5 6 7 8 9 10");

        }
        public static void AddEdge(Node AddTo, Node AddThis, int weight)
        {
            AddTo.Edges.Add(new Edge
            {
                Node = AddThis,
                Weight = weight
            });
            AddThis.Edges.Add(new Edge
            {
                Node = AddTo,
                Weight = weight
            });
        }
        public static void DFS(Node Node, int value)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Looking for node with value {value} using DFS:");
            Stack<Node> Nodes = new Stack<Node>();
            Nodes.Push(Node);
            while (Nodes.Count > 0)
            {
                Node current = Nodes.Pop();
                current.Visited = true;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"===> ({current.Value}) ===");
                /*if (current.Value == value)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"(!!Found it!!) ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }*/
                foreach (Edge next in current.Edges)
                {
                    if (next.Node.Visited == false)
                    {
                        Nodes.Push(next.Node);
                        Console.Write($"{next.Weight}");
                        break;
                    }
                    
                    
                }
            }
            Console.Write("===> STOP");
            Console.ResetColor();
        }

        public static void BFS(Node Node, int value)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Looking for node with value {value} using BFS:");
            Queue<Node> Nodes = new Queue<Node>();
            Nodes.Enqueue(Node);
            while (Nodes.Count > 0)
            {
                if (Nodes.Peek().Visited == false)
                {
                    Node current = Nodes.Dequeue();
                    current.Visited = true;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{current.Value} ");
                    /*if (current.Value == value)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"(<== Found it!) ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }*/
                    foreach (Edge next in current.Edges)
                        if (next.Node.Visited != true)
                            Nodes.Enqueue(next.Node);
                }
                else
                {
                    Nodes.Dequeue();
                }
            }
            Console.ResetColor();
        }

        public static void ClearVisited(Node Node)
        {
            Queue<Node> Nodes = new Queue<Node>();
            Nodes.Enqueue(Node);
            while (Nodes.Count > 0)
            {
                Node current = Nodes.Dequeue();
                current.Visited = false;
                foreach (Edge next in current.Edges)
                    if (next.Node.Visited != false)
                        Nodes.Enqueue(next.Node);
            }
        }
    }
}
