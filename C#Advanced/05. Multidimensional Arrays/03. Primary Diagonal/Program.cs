using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            

            int[,] matrix = new int[size, size];
            int primaryDiagonalSum = 0;
            for (int i = 0; i < size; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = currentRow[j];
                    if (i==j)
                    {
                        primaryDiagonalSum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
