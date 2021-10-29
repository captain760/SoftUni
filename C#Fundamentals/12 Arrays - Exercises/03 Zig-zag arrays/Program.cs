using System;
using System.Linq;

namespace _03_Zig_zag_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Create a program that creates 2 arrays.You will be given an integer n.On the next n lines, you will get 2 integers.
            //  Form 2 new arrays in a zig-zag pattern as shown below.
            int couples = int.Parse(Console.ReadLine());
            int[] firstRow = new int[couples];
            int[] secondRow = new int[couples];
            int[] input = new int[2];

            for (int i = 1; i <= couples; i++)
            {
                if (i % 2 != 0)
                {
                    input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    firstRow[i - 1] = input[0];
                    secondRow[i - 1] = input[1];
                }
                else
                {
                    input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    secondRow[i - 1] = input[0];
                    firstRow[i - 1] = input[1];
                }
            }
            Console.WriteLine(string.Join(" ",firstRow));
            Console.WriteLine(string.Join(" ",secondRow));
        }
    }
}
