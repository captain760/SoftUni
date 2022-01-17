using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int[] jaggedRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                jaggedArray[i] = new int[jaggedRow.Length];
                for (int j = 0; j < jaggedRow.Length; j++)
                {
                    jaggedArray[i][j] = jaggedRow[j];
                }
            }
            string input = Console.ReadLine();
            while (input!="END")
            {
                string[] cmd = input.Split().ToArray();
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);
                if (row >= 0 && col >= 0 && row < rows && col < jaggedArray[row].Length)
                {

                    if (cmd[0] == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    if (cmd[0] == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
