using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] plot = new char[n, n];
            int snakeRow = 0;
            int snakeCol = 0;
            int lair1Row = 0;
            int lair2Row = 0;
            int lair1Col = 0;
            int lair2Col = 0;
            
            bool lairNested = false;
            for (int i = 0; i < n; i++)
            {
                string currRow = Console.ReadLine();
                
                for (int j = 0; j < n; j++)
                {
                    plot[i, j] = currRow[j];
                    if (plot[i, j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                        plot[i, j] = '.';
                    }
                    if (plot[i, j] == 'B' && lairNested == false)
                    {
                        lair1Row = i;
                        lair1Col = j;
                        lairNested = true;
                    }
                    if (plot[i, j] == 'B' && lairNested == true)
                    {
                        lair2Row = i;
                        lair2Col = j;
                    }
                }
            }
            int row = snakeRow;
            int col = snakeCol;
            int food = 0;
            string cmd = Console.ReadLine();
            while (food<10 && IsValid(n, row, col))
            {
                plot[row, col] = '.';
                if (cmd == "up")
                {
                    row--;
                    if (IsValid(n, row, col))
                    {
                        if (row == lair1Row && col == lair1Col)
                        {
                            plot[row, col] = '.';
                            row = lair2Row;
                            col = lair2Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (row == lair2Row && col == lair2Col)
                        {
                            plot[row, col] = '.';
                            row = lair1Row;
                            col = lair1Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (IsValid(n, row, col) && plot[row, col] == '*')
                        {
                            food++;
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
                        if (row == lair1Row && col == lair1Col)
                        {
                            plot[row, col] = '.';
                            row = lair2Row;
                            col = lair2Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (row == lair2Row && col == lair2Col)
                        {
                            plot[row, col] = '.';
                            row = lair1Row;
                            col = lair1Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (IsValid(n, row, col) && plot[row, col] == '*')
                        {
                            food++;
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
                        if (row == lair1Row && col == lair1Col)
                        {
                            plot[row, col] = '.';
                            row = lair2Row;
                            col = lair2Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (row == lair2Row && col == lair2Col)
                        {
                            plot[row, col] = '.';
                            row = lair1Row;
                            col = lair1Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (IsValid(n, row, col) && plot[row, col] == '*')
                        {
                            food++;
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
                        if (row == lair1Row && col == lair1Col)
                        {
                            plot[row, col] = '.';
                            row = lair2Row;
                            col = lair2Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (row == lair2Row && col == lair2Col)
                        {
                            plot[row, col] = '.';
                            row = lair1Row;
                            col = lair1Col;
                            plot[row, col] = '.';
                            cmd = Console.ReadLine();
                            continue;
                        }
                        if (IsValid(n, row, col) && plot[row, col] == '*')
                        {
                            food++;
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
            if (!IsValid(n, row, col))
            {
                Console.WriteLine("Game over!");
            }
            if (food == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                if (IsValid(n, row, col))
                {
                    plot[row, col] = 'S';
                }
            }
            
                if (IsValid(n, row, col))
                {
                    plot[row, col] = 'S';
                }
                Console.WriteLine($"Food eaten: {food}");
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(plot[i, j]);
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


