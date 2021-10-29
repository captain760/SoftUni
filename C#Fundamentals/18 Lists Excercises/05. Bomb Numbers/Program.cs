using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a program that reads a sequence of numbers and a special bomb number holding a certain power. Your task
            //is to detonate every occurrence of the special bomb number and according to its power the numbers to its left and
            //right.The bomb power refers to how many numbers to the left and right will be removed, no matter their values.
            //Detonations are performed from left to right and all the detonated numbers disappear.Finally, print the sum of the
            //remaining elements in the sequence.
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int tempCount = nums.Count;
            int i = 0;
            while (nums.Contains(bomb[0]))
            {
                    i = nums.IndexOf(bomb[0]);
                  
                    for (int j = bomb[1]; j >0; j--)
                    {
                        if (i+j<tempCount && i+j >= 0)
                        {
                            nums.RemoveAt(i+j);
                      
                        }
                    }
                nums.Remove(bomb[0]);
                for (int j = 1; j <= bomb[1]; j++)
                    {
                        if ( i-j >=0 && i-j < tempCount)
                        {
                            nums.RemoveAt(i-j);
                            
                        }
                    }
                tempCount = nums.Count;
            }
            int sum = 0;
            for ( i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
            }
            Console.WriteLine(sum);
        }
    }
}
