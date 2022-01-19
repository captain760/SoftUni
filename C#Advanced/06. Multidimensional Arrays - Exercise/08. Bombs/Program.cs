using System;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
//reading
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] inputs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = inputs[j];
                }
            }
            string[] bombs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < bombs.Length; i++)
            {
                int[] currentBomb = bombs[i].Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int bombRow = currentBomb[0];
                int bombCol = currentBomb[1];
                //logic
                int bombValue = matrix[bombRow, bombCol];
                if (bombValue <= 0)
                {
                    continue;
                }
                for (int k = bombRow-1; k <= bombRow+1; k++)
                {
                    for (int l = bombCol-1; l <= bombCol+1; l++)
                    {
                        if (k>=0 && k<n && l>=0 && l<n)
                        {
                            if (matrix[k,l]>0)
                            {
                                matrix[k, l] -= bombValue;
                            }
                        }
                    }
                }
            }
            //Checking Alive Cells and Summing their values.
            int sum = 0;
            int aliveCount = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j]>0)
                    {
                        sum += matrix[i, j];
                        aliveCount++;
                    }
                }
            }
            //printing
            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {sum}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
