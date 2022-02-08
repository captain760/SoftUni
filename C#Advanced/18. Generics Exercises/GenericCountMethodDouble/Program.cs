using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> list = new List<Box<double>>();
            int integerValue = int.Parse(Console.ReadLine());
            for (int i = 0; i < integerValue; i++)
            {
                double stringValue = double.Parse(Console.ReadLine());
                Box<double> strBox = new Box<double>(stringValue);
                list.Add(strBox);
            }
            double element = double.Parse(Console.ReadLine());
            Console.WriteLine(GreaterCount(list, element));
        }
        public static int GreaterCount(List<Box<double>> list, double element)
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (item.Value.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
