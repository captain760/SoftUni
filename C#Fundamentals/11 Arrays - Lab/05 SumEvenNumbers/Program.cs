using System;
using System.Linq;

namespace _05_SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read an array from the console and sum only its even values.
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfEvens = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]%2 ==0)
                {
                    sumOfEvens += numbers[i];
                }
            }
            Console.WriteLine(sumOfEvens);
        }
    }
}
