using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> numberOccurrance = new Dictionary<double, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numberOccurrance.ContainsKey(numbers[i]))
                {
                    numberOccurrance.Add(numbers[i], 0);
                }
                numberOccurrance[numbers[i]]++;
            }
            foreach (var item in numberOccurrance)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
