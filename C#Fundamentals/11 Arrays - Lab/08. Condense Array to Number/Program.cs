using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program to read an array of integers and condense them by summing all adjacent couples of elements
            //until a single integer remains.
            //For example, let us say we have 3 elements - { 2, 10, 3}. We sum the first two and the second two elements and
            //get { 2 + 10, 10 + 3} = { 12, 13}, then we sum all adjacent elements again.This results in { 12 + 13} = { 25}.
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int l = array.Length;
            int[] condensed = new int[l];
            while (l>1)
            {
                l = condensed.Length;
                l--;
                condensed = new int[l];
                for (int i = 0; i < l; i++)
                {
                    condensed[i] = array[i] + array[i + 1];

                    array[i] = condensed[i];
                }
            }
            Console.WriteLine(array[0]);
        }
    }
}
