using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading
            int[] size = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];            
            char[,] field = new char[n, m];
            char[,] fieldNew = new char[n, m];
            int initRow = 0;
            int initCol = 0;
                       
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    field[i, j] = input[j];
                    fieldNew[i, j] = input[j];

                    if (input[j] == 'P')
                    {
                        initRow = i;
                        initCol = j;
                        field[i, j] = '.';
                        fieldNew[i, j] = '.';
                    }
                }
            }
            string cmd = Console.ReadLine();
            //logic
            int row = initRow;
            int col = initCol;
            bool endGameWin = false;
            bool endGameLose = false;
            for (int i = 0; i < cmd.Length; i++)
            {
                char dir = cmd[i];
                switch (dir)
                {
                    case 'U':
                        {
                            row--;
                            break;
                        }
                    case 'D':
                        {
                            row++;
                            break;
                        }
                    case 'R':
                        {
                            col++;
                            break;
                        }
                    case 'L':
                        {
                            col--;
                            break;
                        }
                }
                if (row < 0 || col < 0 || row >= n || col >= m)
                {
                    switch (dir)
                    {
                        case 'U':
                            {
                                row++;
                                break;
                            }
                        case 'D':
                            {
                                row--;
                                break;
                            }
                        case 'R':
                            {
                                col--;
                                break;
                            }
                        case 'L':
                            {
                                col++;
                                break;
                            }
                    }
                    endGameWin = true;
                    
                }
                for (int k = 0; k < n; k++)
                {
                    for (int l = 0; l < m; l++)
                    {
                        if (field[k,l] == 'B')
                        {
                            if (k>=1)
                            {
                                fieldNew[k - 1, l] = 'B';
                            }
                            if (k<n-1)
                            {
                                fieldNew[k + 1, l] = 'B';
                            }
                            if (l>=1)
                            {
                                fieldNew[k, l - 1] = 'B';
                            }
                            if (l<m-1)
                            {
                                fieldNew[k, l + 1] = 'B';
                            }                            
                        }
                    }
                }
                for (int q = 0; q < n; q++)
                {
                    for (int w = 0; w < m; w++)
                    {
                        field[q, w] = fieldNew[q, w];
                    }
                }
                if (endGameWin)
                {
                    break;
                }
                if (field[row, col] == 'B')
                {
                    endGameLose = true;
                    break;
                }

                
            }
            //printing
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
            if (endGameWin == true)
            {
                Console.WriteLine($"won: {row} {col}");
                return;
            }
            if (endGameLose == true)
            {
                Console.WriteLine($"dead: {row} {col}");
            }

            
        }
    }
}
