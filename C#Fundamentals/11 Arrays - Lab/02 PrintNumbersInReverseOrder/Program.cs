﻿using System;

namespace _02_PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read n numbers and print them in reverse order, separated by a single space.
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
