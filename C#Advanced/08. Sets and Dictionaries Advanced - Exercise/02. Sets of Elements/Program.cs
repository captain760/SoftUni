﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < input[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }
            for (int i = 0; i < input[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(String.Join(" ",firstSet));            
        }
    }
}