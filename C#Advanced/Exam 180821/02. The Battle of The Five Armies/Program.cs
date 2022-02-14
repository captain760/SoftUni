using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int e = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] rows = new string[n];
            for (int i = 0; i < n; i++)
            {
                rows[i] = Console.ReadLine();
            }
            char[,] map = new char[n, rows[0].Length];
            int armyRow = 0;
            int armyCol = 0;
            int mordorRow = 0;
            int mordorCol = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < rows[0].Length; j++)
                {
                    map[i, j] = rows[i][j];
                    if (map[i, j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                        map[i, j] = '-';
                    }
                    if (map[i, j] == 'M')
                    {
                        mordorRow = i;
                        mordorCol = j;
                    }
                }
            }
            bool reachesMordor = false;
            while (e > 0 || reachesMordor == false)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int orcRow = int.Parse(cmd[1]);
                int orcCol = int.Parse(cmd[2]);
                map[orcRow, orcCol] = 'O';

                if (cmd[0] == "up")
                {
                    if (armyRow > 0)
                    {
                        armyRow--;
                        if (map[armyRow, armyCol] == 'O')
                        {
                            e -= 3;
                            if (e>0)
                            {
                                map[armyRow, armyCol] = '-';
                            }
                        }
                        else
                        {
                            e--;
                        }
                        if (armyRow == mordorRow && armyCol == mordorCol)
                        {
                            reachesMordor = true;
                            break;
                        }
                        if (e <= 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        e--;
                    }
                   

                }
                if (cmd[0] == "down")
                {
                    if (armyRow < n - 1)
                    {
                        armyRow++;
                        if (map[armyRow, armyCol] == 'O')
                        {
                            e -= 3;
                            if (e > 0)
                            {
                                map[armyRow, armyCol] = '-';
                            }
                        }
                        else
                        {
                            e--;
                        }
                        if (armyRow == mordorRow && armyCol == mordorCol)
                        {
                            reachesMordor = true;
                            break;
                        }
                        if (e <= 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        e--;
                    }

                }
                if (cmd[0] == "right")
                {
                    if (armyCol < rows[0].Length - 1)
                    {
                        armyCol++;
                        if (map[armyRow, armyCol] == 'O')
                        {
                            e -= 3;
                            if (e > 0)
                            {
                                map[armyRow, armyCol] = '-';
                            }
                        }
                        else
                        {
                            e--;
                        }
                        if (armyRow == mordorRow && armyCol == mordorCol)
                        {
                            reachesMordor = true;
                            break;
                        }
                        if (e <= 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        e--;
                    }

                }
                if (cmd[0] == "left")
                {
                    if (armyCol > 0)
                    {
                        armyCol--;
                        if (map[armyRow, armyCol] == 'O')
                        {
                            e -= 3;
                            if (e > 0)
                            {
                                map[armyRow, armyCol] = '-';
                            }
                        }
                        else
                        {
                            e--;
                        }
                        if (armyRow == mordorRow && armyCol == mordorCol)
                        {
                            reachesMordor = true;
                            break;
                        }
                        if (e <= 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        e--;
                    }

                }


            }
            if (e <= 0)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                map[armyRow, armyCol] = 'X';
            }
            if (reachesMordor)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                map[armyRow, armyCol] = '-';
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < rows[0].Length; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
