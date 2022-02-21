using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            int initRow = 0;
            int initCol = 0;
            int totalWoods = 0;
            for (int i = 0; i < n; i++)
            {
                char[] rowElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(char.Parse)
                     .ToArray();
                for (int j = 0; j < rowElements.Length; j++)
                {
                    pond[i, j] = rowElements[j];
                    if (pond[i,j] == 'B')
                    {
                        initRow = i;
                        initCol = j;
                    }
                    if (char.IsLower(pond[i,j]))
                    {
                        totalWoods++;
                    }
                }
            }
            List<char> woods = new List<char>();
            int row = initRow;
            int col = initCol;
            string input = Console.ReadLine();
            while (input !="end" )
            {
                if (input == "up")
                {
                    if (IsValid(n,row-1,col))
                    {
                        pond[row, col] = '-';
                        row--;
                        if (char.IsLower(pond[row,col]))
                        {
                            woods.Add(pond[row, col]);
                        }
                        if (pond[row,col] == 'F')
                        {
                            pond[row, col] = '-';
                            if (row == 0)
                            {
                                row = n - 1;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }
                            else if (row <= n-1)
                            {
                                row = 0;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }

                        }
                    }
                    else
                    {
                        if (woods.Count>0)
                        {
                            woods.RemoveAt(woods.Count - 1);
                            totalWoods--;
                        }
                    }
                }
                if (input == "down")
                {
                    if (IsValid(n, row + 1, col))
                    {
                        pond[row, col] = '-';
                        row++;
                        if (char.IsLower(pond[row, col]))
                        {
                            woods.Add(pond[row, col]);
                        }
                        if (pond[row, col] == 'F')
                        {
                            pond[row, col] = '-';
                            if (row == n-1)
                            {
                                row = 0;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }
                            else if (row >= 0)
                            {
                                row = n-1;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }

                        }
                    }
                    else
                    {
                        if (woods.Count > 0)
                        {
                            woods.RemoveAt(woods.Count - 1);
                            totalWoods--;
                        }
                    }
                }
                if (input == "left")
                {
                    if (IsValid(n, row , col-1))
                    {
                        pond[row, col] = '-';
                        col--;
                        if (char.IsLower(pond[row, col]))
                        {
                            woods.Add(pond[row, col]);
                        }
                        if (pond[row, col] == 'F')
                        {
                            pond[row, col] = '-';
                            if (col == 0)
                            {
                                col = n - 1;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }
                            else if (col >0)
                            {
                                col = 0;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }

                        }
                    }
                    else
                    {
                        if (woods.Count > 0)
                        {
                            woods.RemoveAt(woods.Count - 1);
                            totalWoods--;
                        }
                    }
                }
                if (input == "right")
                {
                    if (IsValid(n, row, col + 1))
                    {
                        pond[row, col] = '-';
                        col++;
                        if (char.IsLower(pond[row, col]))
                        {
                            woods.Add(pond[row, col]);
                        }
                        if (pond[row, col] == 'F')
                        {
                            pond[row, col] = '-';
                            if (col == n-1)
                            {
                                col = 0;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }
                            else if (col < n-1)
                            {
                                col = n-1;
                                if (char.IsLower(pond[row, col]))
                                {
                                    woods.Add(pond[row, col]);
                                }
                            }

                        }
                    }
                    else
                    {
                        if (woods.Count > 0)
                        {
                            woods.RemoveAt(woods.Count - 1);
                            totalWoods--;
                        }
                    }
                }
                if (woods.Count==totalWoods)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            pond[row, col] = 'B';
            if (woods.Count == totalWoods)
            {
                Console.Write($"The Beaver successfully collect {totalWoods} wood branches: {string.Join(", ",woods)}.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalWoods-woods.Count} branches left.");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(pond[i,j]+" ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int n, int v, int col) =>
            v >= 0 && col >= 0 && v < n && col < n;
    }
}
