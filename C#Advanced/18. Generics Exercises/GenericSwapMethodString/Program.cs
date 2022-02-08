using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = new List<Box<string>>();
            int integerValue = int.Parse(Console.ReadLine());
            for (int i = 0; i < integerValue; i++)
            {
                string stringValue = Console.ReadLine();
                Box<string> strBox = new Box<string>(stringValue);
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
        public static List<Box<string>> Swap(List<Box<string>> list, int first, int last)
        {
            var temp = list[first];
            list[first] = list[last];
            list[last] = temp;
            return list;
        }
    }
}
