using System;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int n = size[0];
            int m = size[1];
            int[,] plot = new int[n, m];
            string input = Console.ReadLine();
            while (input!="Bloom Bloom Plow")
            {
                int[] cmd = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = cmd[0];
                int col = cmd[1];
                if (!IsValid(plot,row,col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    input = Console.ReadLine();
                    continue;
                }
                for (int i = 0; i < n; i++)
                {
                    plot[i, col]++;
                }
                for (int j = 0; j < m; j++)
                {
                    plot[row, j]++;
                }
                plot[row, col]--;
                input = Console.ReadLine();
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(plot[i,j]+" ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int[,] plot, int row, int col)
        {
            if (row>=0 && col>=0 &&row<plot.GetLength(0) && col<plot.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
