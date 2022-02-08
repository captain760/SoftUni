using System;
using System.Collections.Generic;

namespace GenericCountMethodString
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
            string element = Console.ReadLine();
            Console.WriteLine(GreaterCount(list,element));
        }
        public static int GreaterCount(List<Box<string>> list,string element)
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (item.Value.CompareTo(element)>0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
