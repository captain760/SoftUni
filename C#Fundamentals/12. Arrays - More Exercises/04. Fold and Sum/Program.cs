using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read an array of 4 * k integers, fold it like shown below, and print the sum of the upper and lower two rows(each
            //holding 2 * k integers):

            // Create the first row after folding: the first k numbers reversed, followed by the last k numbers reversed.
            // Create the second row after folding: the middle 2 * k numbers.
            // Sum the first and the second rows.
            int[] initialArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = initialArray.Length / 4;
            int[] foldArray = new int[2 * k];
            int[] midArray = new int[2 * k];
            if (k > 1)
            {
                for (int i = 0; i < k; i++)
                {
                    foldArray[i] = initialArray[k - i - 1];
                }
                for (int i = k; i < 2 * k; i++)
                {
                    foldArray[i] = initialArray[5 * k - i - 1];
                }
                for (int i = 0; i < 2 * k; i++)
                {
                    midArray[i] = initialArray[k + i];
                }
                //Console.WriteLine(string.Join(" ",foldArray));
                //Console.WriteLine(string.Join(" ",midArray));
                for (int i = 0; i < 2 * k; i++)
                {
                    midArray[i] = midArray[i] + foldArray[i];
                }
                Console.WriteLine(string.Join(" ", midArray));
            }
            else if (k == 1)
            {
                Console.WriteLine($"{initialArray[0] + initialArray[1]} {initialArray[2] + initialArray[3]}");
            }
        }
    }
}
