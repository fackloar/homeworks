using System;

namespace Project_1
{
    class Program
    {
        public class random
        {           
                public static void diagonal(int i, int j, int k, int v, int[,] arr) 
                {
                    for (;i < k && j < v; i++, j++)
                    {  
                        Console.Write($"{new string(' ', j)}{arr[i, j]}");
                        space();
                    }
                }
                public static void space()
                {
                    Console.WriteLine();
                }
                static void Main(string[] args)
                {
                    var rand = new Random();
                    int[,] matrix = new int[5, 5];
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                matrix[i,j] = rand.Next(0, 9);
                            }
                    }
                    Console.WriteLine("A random grid of numbers 5x5");
                    space();
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        space();
                    }
                    space();
                    Console.WriteLine("This is the main diagonal: ");
                    diagonal(0, 0, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    Console.WriteLine("These are two smaller diagonals:");
                    space();
                    diagonal(0, 1, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    space();
                    diagonal(1, 0, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    Console.WriteLine("These are two even smaller diagonals:");
                    space();
                    diagonal(0, 2, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    space();
                    diagonal(2, 0, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    space();
                    Console.WriteLine("These are two even smaller diagonals:");
                    space();
                    diagonal(0, 3, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    space();
                    diagonal(3, 0, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    space();
                    Console.WriteLine("These are the smallest diagonals:");
                    diagonal(0, 4, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    space();
                    diagonal(4, 0, matrix.GetLength(0), matrix.GetLength(1), matrix);
                    
                    /*for (int i = 0, j = 0; i < matrix.GetLength(0) && j < matrix.GetLength(1); i++, j++)
                    {  
                        Console.Write($"{new string(' ', i)}{matrix[i, j]}");
                        space();
                    }
                    space();
                    Console.WriteLine("These are two smaller diagonals:");
                    space();
                    for (int i = 0, j = 1; i < matrix.GetLength(0) && j < matrix.GetLength(1); i++, j++)
                    {  
                        Console.Write($"{new string(' ', i)}{matrix[i, j]}");
                        space();
                    }
                    for (int i = 1, j = 0; i < matrix.GetLength(0) && j < matrix.GetLength(1); i++, j++)
                    {  
                        Console.Write($"{new string(' ', i)}{matrix[i, j]}");
                        space();
                    } */
                    Console.ReadKey(); 
                }
        }
    }
}
