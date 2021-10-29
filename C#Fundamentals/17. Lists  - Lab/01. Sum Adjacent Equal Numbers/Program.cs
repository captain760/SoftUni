using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program to sum all of the adjacent equal numbers in a list of decimal numbers, starting from left to right.
            // After two numbers are summed, the result could be equal to some of its neighbors and should be summed
            //as well (see the examples below)
            // Always sum the leftmost two equal neighbors(if several couples of equal neighbors are available)
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            bool isChanged = true;
            while (isChanged && nums.Count>1)
            {


                for (int i = 0; i < nums.Count - 1; i++)
                {
                    if (nums[i] == nums[i + 1])
                    {
                        double sum = nums[i] + nums[i + 1];
                        nums.RemoveAt(i);
                        nums.RemoveAt(i);
                        nums.Insert(i, sum);
                        
                        isChanged = true;
                        break;
                    }
                    else
                    {
                        isChanged = false;
                    }
                }
                
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
