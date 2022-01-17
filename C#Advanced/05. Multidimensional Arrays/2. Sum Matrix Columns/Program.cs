using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
         
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                    
                }
            }
            for (int i = 0; i < cols; i++)
            {
                int colSum = 0;
                for (int j = 0; j < rows; j++)
                {
                    colSum += matrix[j, i];
                }
                Console.WriteLine(colSum);
            }
        }
    }
}
