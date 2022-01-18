using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            //logic
            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i <= rows-3; i++)
            {
                for (int j = 0; j <= cols-3; j++)
                {
                    int currSum = 0;
                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            currSum += matrix[i + row, j + col];
                        }
                    }
                    if (currSum>maxSum)
                    {
                        maxSum = currSum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            //printing
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxRow; row < maxRow+3; row++)
            {
                for (int col = maxCol; col <maxCol+ 3; col++)
                {
                    Console.Write(matrix[row,col]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
