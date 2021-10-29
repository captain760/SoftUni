using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that receives a single integer n and prints an NxN matrix using this number as a filler.
            int num = int.Parse(Console.ReadLine());
            PrintMatrix(num);
        }

        private static void PrintMatrix(int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
