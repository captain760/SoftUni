using System;
using System.Linq;

namespace _01._Diagonal_Difference
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
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            //calculating
            int primaryDiag = 0;
            int secondaryDiag = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i==j)
                    {
                        primaryDiag += matrix[i, j];
                    }
                    if (j==n-i-1)
                    {
                        secondaryDiag += matrix[i, j];
                     }
                }
            }
            //printing
            Console.WriteLine(Math.Abs(primaryDiag-secondaryDiag));
        }
    }
}
