using System;
using System.Linq;

namespace _06_Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that calculates the difference between the sum of the even and the sum of the odd numbers in an array.
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfEvens = 0;
            int sumOfOdds = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumOfEvens += numbers[i];
                }
                else
                {
                    sumOfOdds += numbers[i];
                }
            }
            int subtraction = sumOfEvens - sumOfOdds;
            Console.WriteLine(subtraction);
        }
    }
}
