using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            string[] coordinates = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
            List<int[]> points = new List<int[]>();
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] coorElements = coordinates[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] point = new int[2];
                point[0] = coorElements[0];
                point[1] = coorElements[1];
                points.Add(point);
            }
            int spShipsCount = 0;
            int fpShipsCount = 0;
            for (int i = 0; i < n; i++)
            {
                char[] rowSymbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < rowSymbols.Length; j++)
                {
                    field[i, j] = rowSymbols[j];
                    if (field[i, j] == '>')
                    {
                        spShipsCount++;
                    }
                    if (field[i, j] == '<')
                    {
                        fpShipsCount++;
                    }
                }
            }
            int totalShips = fpShipsCount + spShipsCount;
            bool fpWin = false;
            bool spWin = false;
            for (int i = 0; i < points.Count; i++)
            {
                int row = points[i][0];
                int col = points[i][1];
                if (IsValid(n, row, col))
                {                    
                    if (field[row, col] == '>')
                    {
                        field[row, col] = 'X';
                        spShipsCount--;
                    }
                    else if (field[row, col] == '<')
                    {
                        field[row, col] = 'X';
                        fpShipsCount--;
                    }
                    else if (field[row, col] == '#')
                    {
                        field[row, col] = 'X';
                        for (int k = -1; k < 2; k++)
                        {
                            for (int l = -1; l < 2; l++)
                            {
                                if (IsValid(n, row + k, col + l) && (field[row + k, col + l] == '<' || field[row + k, col + l] == '>'))
                                {
                                    if (field[row + k, col + l] == '>')
                                    {
                                        spShipsCount--;
                                        field[row + k, col + l] = 'X'; 
                                    }
                                    else if (field[row + k, col + l] == '<')
                                    {
                                        fpShipsCount--;
                                        field[row + k, col + l] = 'X'; 
                                    }
                                }
                            }                            
                        }                        
                    }
                    if (spShipsCount == 0)
                    {
                        fpWin = true;
                        break;
                    }
                    if (fpShipsCount == 0)
                    {
                        spWin = true;
                        break;
                    }
                }
            }
            int totalShipsDestroyed = totalShips - fpShipsCount - spShipsCount;
            if (fpWin)
            {
                Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (spWin)
            {
                Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {fpShipsCount} ships left. Player Two has {spShipsCount} ships left.");
            }           
        }
        private static bool IsValid(int n, int v1, int v2)
        {
            if (v1 >= 0 && v1 < n && v2 >= 0 && v2 < n)
            {
                return true;
            }
            return false;
        }
    }
}
