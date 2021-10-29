using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program to find all the top integers in an array. A top integer is an integer that is greater than all the
            //elements to its right.
            int[] initialArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] topIntegers = new int[initialArray.Length];
            bool isTop = true;
            int k = 0;

            for (int i = 0; i < initialArray.Length-1; i++)
            {
                for (int j = i+1; j < initialArray.Length; j++)
                {
                    if (initialArray[i]<=initialArray[j])
                    {
                        isTop = false;
                        break;
                    }
                }
                if (isTop)
                {
                    topIntegers[k] = initialArray[i];
                    k++;
                    
                }
                isTop = true;
            }
            topIntegers[k] = initialArray[initialArray.Length - 1];
            for (int i = 0; i < k+1; i++)
            {
                Console.Write(topIntegers[i] + " ");
            }
        }
    }
}
