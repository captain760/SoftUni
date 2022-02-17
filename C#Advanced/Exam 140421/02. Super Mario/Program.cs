using System;
using System.Linq;

namespace _02._Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int e = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string firstRow = Console.ReadLine();
            char[,] tower = new char[n,firstRow.Length];
            int initRow = 0;
            int initCol = 0;
            int prRow = 0;
            int prCol = 0;
            for (int i = 0; i < firstRow.Length; i++)
            {
                tower[0, i] = firstRow[i];
                if (firstRow[i] == 'P')
                {
                    prRow = 0;
                    prCol = i;
                }
                if (firstRow[i] == 'M')
                {
                    initRow = 0;
                    initCol = i;
                    tower[0, i] = '-';
                }
            }
            if (n>0)
            {
                for (int i = 1; i < n; i++)
                {
                    string curRow = Console.ReadLine();
                    for (int j = 0; j < firstRow.Length; j++)
                    {
                        tower[i, j] = curRow[j];
                        if (curRow[j] == 'P')
                        {
                            prRow = i;
                            prCol = j;
                        }
                        if (curRow[j] == 'M')
                        {
                            initRow = i;
                            initCol = j;
                            tower[i, j] = '-';
                        }
                    }
                }
            }
            
            int row = initRow;
            int col = initCol;
            bool isDead = false;
            bool isWin = false;
            while (!isDead && !isWin)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int spawnRow = int.Parse(cmd[1]);
                int spawnCol = int.Parse(cmd[2]);
                tower[spawnRow, spawnCol] = 'B';
                char dir = char.Parse(cmd[0]);
                
                switch (dir)
                {
                    case 'W':
                        {
                            if (IsValid(tower,row-1,col))
                            {
                                row--;
                                e--;
                            }
                            else
                            {
                                e--;
                            }
                            if (tower[row,col] == 'B')
                            {
                                e -= 2;
                                if (e>0)
                                {
                                    tower[row, col] = '-';
                                }
                            }
                            if (row == prRow && col == prCol)
                            {
                                isWin = true;
                                tower[row, col] = '-';
                                break;
                            }
                            if (e<=0)
                            {
                                tower[row, col] = 'X';
                                isDead = true;
                            }
                            
                            break;
                        }
                    case 'S':
                        {
                            if (IsValid(tower, row + 1, col))
                            {
                                row++;
                                e--;
                            }
                            else
                            {
                                e--;
                            }
                            if (tower[row, col] == 'B')
                            {
                                e -= 2;
                                if (e > 0)
                                {
                                    tower[row, col] = '-';
                                }
                            }
                            if (row == prRow && col == prCol)
                            {
                                isWin = true;
                                tower[row, col] = '-';
                                break;
                            }
                            if (e <= 0)
                            {
                                tower[row, col] = 'X';
                                isDead = true;
                            }

                            break;
                        }
                    case 'A':
                        {
                            if (IsValid(tower, row , col-1))
                            {
                                col--;
                                e--;
                            }
                            else
                            {
                                e--;
                            }
                            if (tower[row, col] == 'B')
                            {
                                e -= 2;
                                if (e > 0)
                                {
                                    tower[row, col] = '-';
                                }
                            }
                            if (row == prRow && col == prCol)
                            {
                                isWin = true;
                                tower[row, col] = '-';
                                break;
                            }
                            if (e <= 0)
                            {
                                tower[row, col] = 'X';
                                isDead = true;
                            }

                            break;
                        }
                    case 'D':
                        {
                            if (IsValid(tower, row , col+1))
                            {
                                col++;
                                e--;
                            }
                            else
                            {
                                e--;
                            }
                            if (tower[row, col] == 'B')
                            {
                                e -= 2;
                                if (e > 0)
                                {
                                    tower[row, col] = '-';
                                }
                            }
                            if (row == prRow && col == prCol)
                            {
                                isWin = true;
                                tower[row, col] = '-';
                                break;
                            }
                            if (e <= 0)
                            {
                                tower[row, col] = 'X';
                                isDead = true;
                            }

                            break;
                        }
                }
            }
            if (isDead)
            {
                Console.WriteLine($"Mario died at {row};{col}.");
            }
            if (isWin)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {e}");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < firstRow.Length; j++)
                {
                    Console.Write(tower[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(char[,] tower, int row, int col)
        {
            if (row>=0 && row<tower.GetLength(0))
            {
                if (col >= 0 && col < tower.GetLength(1))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
