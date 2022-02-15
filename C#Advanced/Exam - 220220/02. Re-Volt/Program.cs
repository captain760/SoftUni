using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int initRow = 0;
            int initCol = 0;
            for (int i = 0; i < n; i++)
            {
                string currRow = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = currRow[j];
                    if (currRow[j] == 'f')
                    {
                        initRow = i;
                        initCol = j;
                        field[i, j] = '-';
                    }
                }
            }
            int row = initRow;
            int col = initCol;
            bool isFinish = false;
            for (int i = 0; i < c; i++)
            {
                string cmd = Console.ReadLine();
                if (cmd == "up")
                {
                    if (IsValid(n,row-1,col))
                    {
                        row--;
                    }
                    else
                    {
                        row = n - 1;
                    }
                    if (field[row,col] == 'B')
                    {
                        if (IsValid(n,row-1,col))
                        {
                            row--;
                        }
                        else
                        {
                            row = n - 1;
                        }
                    }
                    if (field[row, col] == 'T')
                    {
                        if (IsValid(n, row + 1, col))
                        {
                            row++;
                        }
                        else
                        {
                            row = 0;
                        }
                    }
                }
                if (cmd == "down")
                {
                    if (IsValid(n, row + 1, col))
                    {
                        row++;
                    }
                    else
                    {
                        row = 0;
                    }
                    if (field[row, col] == 'B')
                    {
                        if (IsValid(n, row + 1, col))
                        {
                            row++;
                        }
                        else
                        {
                            row = 0;
                        }
                    }
                    if (field[row, col] == 'T')
                    {
                        if (IsValid(n, row - 1, col))
                        {
                            row--;
                        }
                        else
                        {
                            row = n-1;
                        }
                    }
                }
                if (cmd == "left")
                {
                    if (IsValid(n, row, col-1))
                    {
                        col--;
                    }
                    else
                    {
                        col = n - 1;
                    }
                    if (field[row, col] == 'B')
                    {
                        if (IsValid(n, row, col-1))
                        {
                            col--;
                        }
                        else
                        {
                            col = n - 1;
                        }
                    }
                    if (field[row, col] == 'T')
                    {
                        if (IsValid(n, row, col+1))
                        {
                            col++;
                        }
                        else
                        {
                            col = 0;
                        }
                    }
                }
                if (cmd == "right")
                {
                    if (IsValid(n, row , col+1))
                    {
                        col++;
                    }
                    else
                    {
                        col = 0;
                    }
                    if (field[row, col] == 'B')
                    {
                        if (IsValid(n, row , col+1))
                        {
                            col++;
                        }
                        else
                        {
                            col=0;
                        }
                    }
                    if (field[row, col] == 'T')
                    {
                        if (IsValid(n, row , col-1))
                        {
                            col--; ;
                        }
                        else
                        {
                            col = n-1;
                        }
                    }
                }
                if (field[row,col] =='F')
                {
                    isFinish = true;
                    field[row, col] = 'f';
                    break;
                }                
            }
            field[row, col] = 'f';
            if (isFinish)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    Console.Write(field[k, l]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int n, int row, int col)
        {
            if (row>=0 && row<n)
            {
                if (col>=0 && col<n)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
