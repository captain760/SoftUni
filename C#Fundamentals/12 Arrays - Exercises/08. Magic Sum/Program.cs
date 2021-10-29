using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Create a program, which prints all unique pairs in an array of integers whose sum is equal to a given number.
            int[] initialArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int reqSum = int. Parse(Console.ReadLine());
            for (int i = 0; i < initialArray.Length-1; i++)
            {
                for (int j = i+1; j < initialArray.Length; j++)
                {
                    if (initialArray[i] + initialArray[j] == reqSum)
                    {
                        Console.WriteLine(initialArray[i]+" "+initialArray[j]);
                    }
                }
            }
        }
    }
}
