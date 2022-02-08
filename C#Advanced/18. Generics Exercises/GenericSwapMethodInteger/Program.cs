using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> list = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int Value = int.Parse(Console.ReadLine());
                Box<int> strBox = new Box<int>(Value);
                list.Add(strBox);
            }
            int[] integerElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

            list = Swap(list, integerElements[0], integerElements[1]);
            foreach (var item in list)
            {
                item.ToString();
            }


        }
        public static List<Box<int>> Swap(List<Box<int>> list, int first, int last)
        {
            var temp = list[first];
            list[first] = list[last];
            list[last] = temp;
            return list;
        }
    }
}
