using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            int currentPos = 0;
            
            for (int i = 0; i < rows; i++)
            {
                if (i%2==0)
                {
                    
                    for (int j = 0; j < cols; j++)
                    {
                        if (currentPos == snake.Length)
                        {
                            currentPos = 0;
                        }
                        matrix[i, j] = snake[currentPos];
                        currentPos++;
                    }
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    
                    {
                        if (currentPos == snake.Length)
                        {
                            currentPos = 0;
                        }
                        matrix[i, j] = snake[currentPos];
                        currentPos++;
                    }
                }
            }
            //printing
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
