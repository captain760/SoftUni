using System;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int initRow = -1;
            int initCol = -1;
            int pilarRow = -1;
            int pilarCol = -1;
            int secondPilarRow = -1;
            int secondPilarCol = -1;
            bool firstpilar = false;
            for (int i = 0; i < n; i++)
            {
                string rowString = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowString[j];
                    if (rowString[j] == 'S')
                    {
                        initRow = i;
                        initCol = j;
                    }
                    if (rowString[j] == 'O' && firstpilar == false)
                    {
                        pilarRow = i;
                        pilarCol = j;
                        firstpilar = true;
                    }
                    else if (rowString[j] == 'O' && firstpilar == true)
                    {
                        secondPilarRow = i;
                        secondPilarCol = j;
                    }

                }
            }
            int row = initRow;
            int col = initCol;
            matrix[initRow, initCol] = '-';
            int profit = 0;

            bool outOfMatrix = false;
            string input = Console.ReadLine();
            while (row >= 0 && col >= 0 && row < n && col < n && profit < 50 && outOfMatrix == false)
            {
                switch (input)
                {
                    case "up":
                        {
                            row--;
                            if (row < 0)
                            {
                               
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                    case "down":
                        {
                            row++;
                            if (row >= n)
                            {
                                
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                    case "left":
                        {
                            col--;
                            if (col < 0)
                            {
                                
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                    case "right":
                        {
                            col++;
                            if (col >= n)
                            {
                                
                                outOfMatrix = true;
                                continue;
                            }
                            break;
                        }
                }
                if (matrix[row, col] == '-')
                {
                    input = Console.ReadLine();
                    continue;
                }
                else if (matrix[row, col] == 'O')
                {
                    if (row == pilarRow && col == pilarCol)
                    {
                        row = secondPilarRow;
                        col = secondPilarCol;
                        matrix[pilarRow, pilarCol] = '-';
                    }
                    else
                    {
                        row = pilarRow;
                        col = pilarCol;
                        matrix[secondPilarRow, secondPilarCol] = '-';
                    }
                    matrix[row, col] = '-';
                }
                else
                {
                    profit += int.Parse(matrix[row, col].ToString());
                    matrix[row, col] = '-';
                    if (profit >= 50)
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            if (row >= 0 && col >= 0 && row < n && col < n)
            {
                matrix[row, col] = 'S';
            }
            
            if (outOfMatrix)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
                
            }
            else if (profit>=50)            
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {profit}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
