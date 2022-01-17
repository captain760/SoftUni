using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());


            char[,] matrix = new char[size, size];
            
            for (int i = 0; i < size; i++)
            {
                string currentRow = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = currentRow[j];
                    
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
