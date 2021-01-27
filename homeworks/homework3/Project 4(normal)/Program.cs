using System;

namespace Project_4_normal_
{
    class Program
    {
        public static void placeShip(char[,] arr ,int i, int j, char ship) 
                {
                    arr[i, j] = ship;
                }
        public static void placeShip2(char[,] arr ,int i, int j, char ship) 
                {
                    arr[i, j] = ship;
                    var rand = new Random();
                    int randAct = rand.Next(0,2);
                    if (randAct == 0)
                    arr[i+1,j] = ship;
                    else
                    arr[i,j+1] = ship;
                }
        public static void placeShip3(char[,] arr ,int i, int j, char ship) 
                {
                    arr[i, j] = ship;
                    var rand = new Random();
                    int randAct = rand.Next(0,2);
                    if (randAct == 0)
                    {
                        for (int k = 0; k <= 2; k++)
                        {
                            arr[i+k,j] = ship;
                        }
                    }
                    else
                    {
                        for (int k = 0; k <= 2; k++)
                        {
                            arr[i,j+k] = ship;
                        }
                    }
                    
                }

        public static void placeShip4(char[,] arr ,int i, int j, char ship) 
        {
           arr[i, j] = ship;
                    var rand = new Random();
                    int randAct = rand.Next(0,2);
                    if (randAct == 0)
                    {
                        for (int k = 0; k <= 3; k++)
                        {
                            arr[i+k,j] = ship;
                        }
                    }
                    else
                    {
                        for (int k = 0; k <= 3; k++)
                        {
                            arr[i,j+k] = ship;
                        }
                    } 
        }
        static void Main(string[] args)
        {
        
        char[,] grid = new char[10, 10];
        char emptySpace = 'O';
        char ship = 'X';
        char ship1 = 'X';
        char ship2 = 'X';
        char ship4 = 'X';
        
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i,j] = emptySpace;
            }
        }

        placeShip(grid, 2, 5, ship);
        placeShip(grid, 4, 5, ship);
        placeShip(grid, 9, 8, ship);
        placeShip(grid, 0, 6, ship);

        placeShip2(grid, 0, 2, ship2);
        placeShip2(grid, 8, 4, ship2);
        placeShip2(grid, 6, 7, ship2);

        placeShip3(grid, 7, 0, ship1);
        placeShip3(grid, 2, 7, ship1);

        placeShip4(grid, 2, 0, ship4);



        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write($"{grid[i, j]}  ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.ReadKey();





        }
    }
}
