using System;
using System.Linq;

namespace recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int index = nums.Length - 1;
            int sum = SumArray(nums, index);
            Console.WriteLine(sum);

        }

        private static int SumArray(int[] nums, int index)
        {

            if (index == 0)
            {
                return nums[0];
            }
            return nums[index] + SumArray(nums, index - 1);

        }
    }
}
