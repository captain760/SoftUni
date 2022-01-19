using System;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading
            int n = int.Parse(Console.ReadLine());
            string[] cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[,] field = new char[n, n];
            int initRow = 0;
            int initCol = 0;
            int endRow = 0;
            int endCol = 0;
            int allCoalsCount = 0;

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    field[i,j] = input[j];
                    if (input[j] == 's')
                    {
                        initRow = i;
                        initCol = j;
                    }
                    if (input[j] == 'e')
                    {
                        endRow = i;
                        endCol = j;
                    }
                    if (input[j] == 'c')
                    {
                        allCoalsCount++;
                    }
                }
            }
            //logic
            int row = initRow;
            int col = initCol;
            int coalCount = 0;
            for (int i = 0; i < cmd.Length; i++)
            {
                string dir = cmd[i];
                switch (dir)
                {
                    case "up":
                        {
                            row--;
                            break;
                        }
                    case "down":
                        {
                            row++;
                            break;
                        }
                    case "right":
                        {
                            col++;
                            break;
                        }
                    case "left":
                        {
                            col--;
                            break;
                        }
                }
                if (row<0 || col<0 || row>=n || col>=n)
                {
                    switch (dir)
                    {
                        case "up":
                            {
                                row++;
                                break;
                            }
                        case "down":
                            {
                                row--;
                                break;
                            }
                        case "right":
                            {
                                col--;
                                break;
                            }
                        case "left":
                            {
                                col++;
                                break;
                            }
                    }
                    continue;
                }
                if (field[row,col] == 'c')
                {
                    coalCount++;
                    field[row, col] = '*';
                }
                
                if (allCoalsCount-coalCount==0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return;
                }
                if (row == endRow && col == endCol)
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
            }
            
            Console.WriteLine($"{allCoalsCount-coalCount} coals left. ({row}, {col})");
        }
    }
}
