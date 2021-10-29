using System;
using System.Linq;

namespace _5._Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read a list of integers and find the longest increasing subsequence(LIS).If several such exist, print the leftmost.


            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int arrayLength = array.Length;
            int currentLength = 1;
            int maxLength = 1;



            int[] lengths = new int[arrayLength];

            for (int i = arrayLength - 1; i >= 0; i--)
            {
                int prev = array[i];
                for (int j = arrayLength - 2; j >= 0; j--)
                {
                    if (array[j] < array[i])
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {


                            if (prev > array[j])
                            {
                                currentLength++;
                                prev = array[k]; 
                            }

                            if (currentLength > maxLength)
                            {
                                maxLength = currentLength;

                            }

                        }
                    }
                }
                currentLength = 1;
                lengths[i] = maxLength;
                maxLength = 1;
            }
            lengths[arrayLength - 1] = 1;
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write(lengths[i] + " ");
            }
        }
    }
}


