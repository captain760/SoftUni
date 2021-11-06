using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SortedDictionary<int, int> numbersOccurances = new SortedDictionary<int, int>();
            foreach (var item in numbers)
            {
                if (numbersOccurances.ContainsKey(item))
                {
                    numbersOccurances[item]++;
                }
                else
                {
                    numbersOccurances.Add(item, 1);
                }
            }
            foreach (var item in numbersOccurances)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
