using System;
using System.Linq;

namespace _02._Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int allTokens = 0;
            int collectedTokens = 0;
            int oponentCollectedTokens = 0;
            char[][] beach = new char[n][];
            for (int i = 0; i < n; i++)
            {
                char[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                beach[i] = new char[tokens.Length];
                for (int j = 0; j < tokens.Length; j++)
                {
                    beach[i][j] = tokens[j];
                    if (tokens[j] == 'T')
                    {
                        allTokens++;
                    }
                }
            }
            string input = Console.ReadLine();
            while (input!="Gong")
            {
                string[] cmd = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "Find")
                {
                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);
                    if (isValid(beach,row,col) && beach[row][col]=='T')
                    {
                        beach[row][col] = '-';
                        collectedTokens++;
                    }
                }
                else
                {
                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);
                    string dir = cmd[3];
                    if (isValid(beach, row, col) && beach[row][col] == 'T')
                    {
                        beach[row][col] = '-';
                        oponentCollectedTokens++;
                        switch (dir)
                        {

                            case "up":
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        if (isValid(beach, row - i, col) && beach[row - i][col] == 'T')
                                        {
                                            beach[row - i][col] = '-';
                                            oponentCollectedTokens++;
                                        }
                                    }
                                    break;
                                }
                            case "down":
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        if (isValid(beach, row + i, col) && beach[row + i][col] == 'T')
                                        {
                                            beach[row + i][col] = '-';
                                            oponentCollectedTokens++;
                                        }
                                    }
                                    break;
                                }
                            case "right":
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        if (isValid(beach, row , col+i) && beach[row][col+i] == 'T')
                                        {
                                            beach[row][col+i] = '-';
                                            oponentCollectedTokens++;
                                        }
                                    }
                                    break;
                                }
                            case "left":
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        if (isValid(beach, row, col - i) && beach[row][col - i] == 'T')
                                        {
                                            beach[row][col - i] = '-';
                                            oponentCollectedTokens++;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < n; i++)
            {                
                    Console.WriteLine(string.Join(" ", beach[i]));                
            }
            Console.WriteLine($"Collected tokens: { collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentCollectedTokens}");
        }

        private static bool isValid(char[][] beach, int row, int col)
        {
            if (row>=0 && row<beach.GetLength(0))
            {
                if (col>=0 && col< beach[row].GetLength(0))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
