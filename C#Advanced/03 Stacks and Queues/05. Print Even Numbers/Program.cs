﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]%2==0)
                {
                    numbers.Enqueue(array[i]);
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
