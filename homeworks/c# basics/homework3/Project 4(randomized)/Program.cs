using System;

namespace Project_4
{
    class Program
    {
        
        public static bool CheckNeighbours(char emptySpace, char[,] field, int x, int y)
        {
            if (field[x, y] == emptySpace && field[x, y+1] == emptySpace && field[x+1, y] == emptySpace && field[x+1, y+1] == emptySpace
                && (x > 0 && field[x-1, y] == emptySpace) && (y > 0 && field[x, y-1] == emptySpace) 
                && (x > 0 && y >0 && field[x-1, y-1] == emptySpace) || ((x == 0 || y == 0) && (field[x, y] == emptySpace || field[x+1, y+1] == emptySpace)))
                {
                    return false;
                }
            else
            return true;
        }
        
        
        
        static void Main(string[] args)
        {
            var rand = new Random();
            char[,] field = new char[11, 11];
            int rowLimit = field.GetLength(0)-1;
            int ColLimit = field.GetLength(1)-1;
            char ship1 = 'X';
            char ship2 = 'B';
            char ship3 = 'C';
            char emptySpace = 'O';

            for (int i = 0; i < rowLimit; i++)
            {
                for (int j = 0; j < ColLimit; j++)
                {
                    field[i, j] = emptySpace;
                }
            }
            
            int xCount = 0;
            while (xCount < 4)
            {
                int randRow = rand.Next(0, rowLimit);
                int randCol = rand.Next(0, ColLimit);
                if (CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                {
                    field[randRow, randCol] = ship1;
                    xCount++;
                }
            }

            
            int bCount = 0;
            while (bCount < 3)
            {
                randomizing:
                int randRow = rand.Next(0, rowLimit);
                int randCol = rand.Next(0, ColLimit);
                if (CheckNeighbours(emptySpace, field, randRow, randCol) == false && field[randRow, randCol] == emptySpace)
                {
                    field[randRow, randCol] = ship2;
                    int randomAction = 0;
                    randomAction = rand.Next(0,2);
                    if (randomAction == 0 && randRow != rowLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow+1, randCol] = ship2;
                    }
                    else if (randomAction == 1 && randCol != ColLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow, randCol+1] = ship2;
                    }
                    else if (randomAction == 0 && randRow == rowLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow-1, randCol] = ship2;
                    }
                    else if (randomAction == 1 && randCol == ColLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow, randCol-1] = ship2;
                    }
                    else if (CheckNeighbours(emptySpace, field, randRow, randCol) == true && randRow != 0 && randCol !=0)
                    {
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j <2; j++)
                            {
                                if (field[randRow+i, randCol+j] == emptySpace)
                                {
                                randomAction = rand.Next(0,2);
                                if (randomAction == 0)
                                    field[randRow+i, randCol] = ship2;
                                else if (randomAction == 1)
                                    field[randRow, randCol+j] = ship2;
                                break;
                                }
                            }
                            break;
                        }
                    }
                    else if (CheckNeighbours(emptySpace, field, randRow, randCol) == true && (randRow == 0 || randCol == 0))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j <2; j++)
                            {
                                if (field[randRow+i, randCol+j] == emptySpace)
                                {
                                randomAction = rand.Next(0,2);
                                if (randomAction == 0)
                                    field[randRow+i, randCol] = ship2;
                                else if (randomAction == 1)
                                    field[randRow, randCol+j] = ship2;
                                break;
                                }
                            }
                            break;
                        }
                    }
                    bCount++;
                }
                else 
                goto randomizing;
            }
            /*int cCount = 0;
            while (cCount < 2)
            {
                randomizing:
                int randRow = rand.Next(0, rowLimit);
                int randCol = rand.Next(0, ColLimit);
                if (CheckNeighbours(emptySpace, field, randRow, randCol) == false && field[randRow, randCol] == emptySpace)
                {
                    field[randRow, randCol] = ship3;
                    int randomAction = 0;
                    randomAction = rand.Next(0,2);
                    if (randomAction == 0 && randRow != rowLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow+1, randCol] = ship3;
                        field[randRow+2, randCol] = ship3;
                    }
                    else if (randomAction == 1 && randCol != ColLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow, randCol+1] = ship3;
                        field[randRow, randCol+2] = ship3;
                    }
                    else if (randomAction == 0 && randRow == rowLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow-1, randCol] = ship3;
                        field[randRow-2, randCol] = ship3;
                    }
                    else if (randomAction == 1 && randCol == ColLimit-1 && CheckNeighbours(emptySpace, field, randRow, randCol) == false)
                    {
                        field[randRow, randCol-1] = ship3;
                        field[randRow, randCol-2] = ship3;
                    }
                    else if (CheckNeighbours(emptySpace, field, randRow, randCol) == true && randRow != 0 && randCol !=0)
                    {
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j <2; j++)
                            {
                                if (field[randRow+i, randCol+j] == emptySpace)
                                {
                                randomAction = rand.Next(0,2);
                                if (randomAction == 0)
                                {
                                    field[randRow+i, randCol] = ship3;
                                    field[randRow+i+1, randCol] = ship3;
                                }
                                else if (randomAction == 1)
                                {
                                    field[randRow, randCol+j] = ship3;
                                    field[randRow, randCol+j+1] = ship3;
                                }
                                break;
                                }
                            }
                            break;
                        }
                    }
                    else if (CheckNeighbours(emptySpace, field, randRow, randCol) == true && (randRow == 0 || randCol == 0))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j <2; j++)
                            {
                                if (field[randRow+i, randCol+j] == emptySpace)
                                {
                                randomAction = rand.Next(0,2);
                                if (randomAction == 0)
                                {
                                    field[randRow+i, randCol] = ship3;
                                    field[randRow+i+1, randCol] = ship3;
                                }
                                else if (randomAction == 1)
                                {
                                    field[randRow, randCol+j] = ship3;
                                    field[randRow, randCol+j+1] = ship3;
                                break;
                                }
                            }
                            break;
                        }
                    }
                    cCount++;
                }
                    else 
                    goto randomizing;
            }
*/


            for (int i = 0; i < rowLimit+1; i++)
            {
                for (int j = 0; j < ColLimit+1; j++)
                {
                    Console.Write($"{field[i,j]} ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}