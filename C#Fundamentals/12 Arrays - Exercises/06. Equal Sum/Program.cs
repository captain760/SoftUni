using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that determines if an element exists in an array for which the sum of all elements to its left is
            //equal to the sum of all elements to its right.If there are no elements to the left or right, their sum is considered to
            //be 0.Print the index of the element that satisfies the condition or " no " if there is no such element.
            int[] initialArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            int symCount = 0;
            for (int i = 0; i < initialArray.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    leftSum += initialArray[j];
                }
                for (int k = i+1; k < initialArray.Length; k++)
                {
                    rightSum += initialArray[k];
                }
                if (leftSum==rightSum )
                {
                    Console.WriteLine(i);
                    symCount++;
                }
                
                leftSum = 0;
                rightSum = 0;
            }
            
            //if (initialArray.Length == 1)
            //{
            //    Console.WriteLine("0");
            //    symCount++;
            //}
            if (symCount==0)
            {
                Console.WriteLine("no");
            }
        }
    }
}
