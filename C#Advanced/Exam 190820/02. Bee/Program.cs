using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] plot = new char[n, n];
            int beeRow = 0;
            int beeCol = 0;
            int bonusRow = 0;
            int bonusCol = 0;
            int polFlowers = 0;
            for (int i = 0; i < n; i++)
            {
                string currRow = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    plot[i, j] = currRow[j];
                    if (plot[i,j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                        plot[i, j] = '.';
                    }
                    if (plot[i, j] == 'O')
                    {
                        bonusRow = i;
                        bonusCol = j;
                    }
                }
            }
            int row = beeRow;
            int col = beeCol;
            string cmd = Console.ReadLine();
            while (IsValid(n,row,col) && cmd!="End")
            {
                if (cmd == "up")
                {
                    row--;
                    if (IsValid(n,row,col))
                    {
                        if (row==bonusRow&& col==bonusCol)
                        {
                            plot[row, col] = '.';
                            row--;
                        }
                        if (IsValid(n,row,col)&& plot[row,col] == 'f')
                        {
                            polFlowers++;
                            plot[row, col] = '.';
                        }
                    }
                    else
                    {                        
                        continue;
                    }
                }
                if (cmd == "down")
                {
                    row++;
                    if (IsValid(n, row, col))
                    {
                        if (row == bonusRow && col == bonusCol)
                        {
                            plot[row, col] = '.';
                            row++;
                        }
                        if (IsValid(n, row, col) && plot[row, col] == 'f')
                        {
                            polFlowers++;
                            plot[row, col] = '.';
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (cmd == "left")
                {
                    col--;
                    if (IsValid(n, row, col))
                    {
                        if (row == bonusRow && col == bonusCol)
                        {
                            plot[row, col] = '.';
                            col--;
                        }
                        if (IsValid(n, row, col) && plot[row, col] == 'f')
                        {
                            polFlowers++;
                            plot[row, col] = '.';
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (cmd == "right")
                {
                    col++;
                    if (IsValid(n, row, col))
                    {
                        if (row == bonusRow && col == bonusCol)
                        {
                            plot[row, col] = '.';
                            col++;
                        }
                        if (IsValid(n, row, col) && plot[row, col] == 'f')
                        {
                            polFlowers++;
                            plot[row, col] = '.';
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                cmd = Console.ReadLine();
            }
            if (!IsValid(n,row,col))
            {
                Console.WriteLine("The bee got lost!");
            }
            if (polFlowers<5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-polFlowers} flowers more");
                if (IsValid(n, row, col))
                {
                    plot[row, col] = 'B';
                }
            }
            else
            {
                if (IsValid(n,row,col))
                {
                    plot[row, col] = 'B';
                }
                Console.WriteLine($"Great job, the bee managed to pollinate {polFlowers} flowers!");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(plot[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int n, int row, int col)
        {
            return (row >= 0 && col >= 0 && row < n && col < n);
        }
    }
}
