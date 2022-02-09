using System;

namespace _02._Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int initRow = -1;
            int initCol = -1;
            int mirrorRow = -1;
            int mirrorCol = -1;
            int secondMirrorRow = -1;
            int secondMirrorCol = -1;
            bool firstMirror = false;
            for (int i = 0; i < n; i++)
            {
                string rowString = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowString[j];
                    if (rowString[j] == 'A')
                    {
                        initRow = i;
                        initCol = j;
                    }
                    if (rowString[j] == 'M' && firstMirror == false)
                    {
                        mirrorRow = i;
                        mirrorCol = j;
                        firstMirror = true;
                    }
                    else if (rowString[j] == 'M' && firstMirror == true)
                    {
                        secondMirrorRow = i;
                        secondMirrorCol = j;
                    }
                    
                }
            }
            int row = initRow;
            int col = initCol;
            matrix[initRow, initCol] = '-';
            int profit = 0;
            
            bool outOfMatrix = false;
            string input = Console.ReadLine();
            while (row>=0 && col>=0 && row<n && col<n && profit<65 && outOfMatrix == false)
            {
                switch (input)
                {
                    case "up":
                        {
                            row--;
                            if (row<0)
                            {
                                row++;
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                    case "down":
                        {
                            row++;
                            if (row>=n)
                            {
                                row--;
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                    case "left":
                        {
                            col--;
                            if (col<0)
                            {
                                col++;
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                    case "right":
                        {
                            col++;
                            if (col>=n)
                            {
                                col--;
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                }
                if (matrix[row,col] == '-')
                {
                    input = Console.ReadLine();
                    continue;
                }
                else if (matrix[row,col] == 'M')
                {
                    if (row == mirrorRow && col == mirrorCol )
                    {
                        row = secondMirrorRow;
                        col = secondMirrorCol;
                        matrix[mirrorRow, mirrorCol] = '-';
                    }
                    else
                    {
                        row = mirrorRow;
                        col = mirrorCol;
                        matrix[secondMirrorRow, secondMirrorCol] = '-';
                    }
                    matrix[row, col] = '-';
                }
                else
                {
                    profit += int.Parse(matrix[row, col].ToString());
                    matrix[row, col] = '-';
                    if (profit>=65)
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            matrix[row, col] = 'A';
            if (profit<65)
            {
                Console.WriteLine("I do not need more swords!");
                matrix[row, col] = '-';
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {profit} gold coins.");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
