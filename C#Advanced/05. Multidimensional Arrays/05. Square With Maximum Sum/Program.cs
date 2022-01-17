using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                    
                }
            }
            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    int sum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (sum>maxSum)
                    {
                        maxRow = i;
                        maxCol = j;
                        maxSum = sum;
                    }
                }
            }
            Console.Write(matrix[maxRow,maxCol]+" ");
            Console.WriteLine(matrix[maxRow,maxCol+1]);
            Console.Write(matrix[maxRow+1, maxCol]+" ");
            Console.WriteLine(matrix[maxRow+1, maxCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
