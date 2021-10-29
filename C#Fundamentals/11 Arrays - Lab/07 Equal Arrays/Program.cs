using System;
using System.Linq;

namespace _07_Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Read two arrays and determine whether they are identical or not.The arrays are identical if all their elements are
            //equal.If the arrays are identical find the sum of the elements of one of them and print the following message to the
            //console: "Arrays are identical.Sum: {sum}"
            //            Otherwise, find the first index where the arrays differ and print the following message to the console: "Arrays are not identical. Found difference at {index}index."
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isNotEqual = false;
            int sum = 0;
            int index = 0;
            if (array1.Length !=array2.Length)
            {
                isNotEqual = true;
            }
            else
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        isNotEqual = true;
                        index = i;
                        break;
                    }
                    else
                    {
                        sum += array1[i];
                    }
                }
            }
            if (isNotEqual)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}
