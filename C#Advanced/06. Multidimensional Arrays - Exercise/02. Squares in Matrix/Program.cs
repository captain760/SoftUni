using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading
            int[] size = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            
               
                for (int i = 0; i < rows; i++)
                {
                    char[] row = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = row[j];
                    }
                }
           
            //calculating
            int counter = 0;
            if (rows>1 && cols>1)
            {
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int j = 0; j < cols - 1; j++)
                    {
                        if (matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1] && matrix[i, j] == matrix[i, j + 1])
                        {
                            counter++;
                        }
                    }
                }
            }
            //printing
            Console.WriteLine(counter);
        }
    }
}
