using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that finds the longest sequence of equal elements in an array of integers. If several equal
            //sequences are present in the array, print out the leftmost one.
            int[] initialArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int collectionLength = 1;
            int bestCollectionLength = 0;
            int collectionIndex = 0;
            int bestCollectionIndex = 0;
            //int k = 0;
            for (int i = 0; i < initialArray.Length-1; i++)
            {
                for (int j = i; j < initialArray.Length; j++)
                {
                    if (initialArray[i] == initialArray[j])
                    {
                        collectionLength++;
                    }
                    else
                    {
                        break;
                    }
                }
                //k = i;
                //while (initialArray[k] == initialArray[k+1] )
                //{
                //    if (k<initialArray.Length-2)
                //    {
                //        k++;
                //        collectionLength++;
                //    }
                //    else
                //    {
                //        break;
                //    }
                                     
                //}
                
                
                collectionIndex = i;
                if (collectionLength>bestCollectionLength)
                {
                    bestCollectionLength = collectionLength;
                    bestCollectionIndex = collectionIndex;
                }
                collectionLength = 1;
            }
            for (int i = bestCollectionIndex; i < bestCollectionIndex + bestCollectionLength-1; i++)
            {
                Console.Write(initialArray[i] + " ");
            }
        }
    }
}
