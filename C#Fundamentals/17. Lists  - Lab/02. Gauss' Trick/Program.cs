using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that sums all numbers in a list in the following order:
            //first + last, first + 1 + last - 1, first + 2 + last - 2, … first + n, last - n.
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int length = nums.Count;
            for (int i = 0; i < length/2; i++)
            {
                nums[i] += nums[length -i - 1];
                nums.RemoveAt(length - i - 1);
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
