using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading Jagged Array
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                int[] array = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedMatrix[i] = new double[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    jaggedMatrix[i][j] = array[j];
                }
            }
            //analizing
            for (int i = 0; i < n-1; i++)
            {
                if (jaggedMatrix[i].Length == jaggedMatrix[i+1].Length)
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] = jaggedMatrix[i][j]*2;
                    }
                    for (int j = 0; j < jaggedMatrix[i+1].Length; j++)
                    {
                        jaggedMatrix[i+1][j] =jaggedMatrix[i+1][j]*2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] =  jaggedMatrix[i][j]/2;
                    }
                    for (int j = 0; j < jaggedMatrix[i + 1].Length; j++)
                    {
                        jaggedMatrix[i + 1][j] =  jaggedMatrix[i + 1][j]/2;
                    }
                }
            }
            //commanding
            string input = Console.ReadLine();
            while (input!="End")
            {
                string[] cmd = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmd.Length!=4)
                {
                    input = Console.ReadLine();
                    continue;
                }
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                double value = double.Parse(cmd[3]);
                if (row<0 || col<0 || row>=n || col>=jaggedMatrix[row].Length)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (cmd[0] == "Add")
                {
                    jaggedMatrix[row][col] += value;
                }
                else if (cmd[0] == "Subtract")
                {
                    jaggedMatrix[row][col] -= value;
                }
                

                input = Console.ReadLine();
            }
            //printing
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jaggedMatrix[i].Length; j++)
                {
                    Console.Write(jaggedMatrix[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
