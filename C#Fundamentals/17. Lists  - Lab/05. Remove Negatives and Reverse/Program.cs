using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Read a list of integers, remove all negative numbers from it and print the remaining elements in reversed order. If
            //there are no elements left in the list, print &quot; empty & quot;.
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            nums.RemoveAll(n => n < 0);
            nums.Reverse();
            if (nums.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
