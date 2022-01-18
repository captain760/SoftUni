using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            //logic
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] cmd = input.Split().ToArray();
                if (cmd.Length != 5)
                {
                    input = Console.ReadLine();
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);
                
                if (cmd[0] != "swap" || row1<0 ||row2<0 || col1<0 || col2<0 ||row1>rows || row2>rows ||col1>cols || col2>cols)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2,col2] = temp;
                    //printing
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Console.Write(matrix[i,j]+ " ");
                        }
                        Console.WriteLine();
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
