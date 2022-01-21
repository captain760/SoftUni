using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentMark = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string name = input[0];
                decimal mark = decimal.Parse(input[1]);
                if (!studentMark.ContainsKey(name))
                {
                    studentMark.Add(name, new List<decimal>());
                }
                studentMark[name].Add(mark);
            }
            foreach (var name in studentMark)
            {
                Console.Write($"{name.Key} -> ");
                foreach (var grade in name.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {name.Value.Average():f2})");
            }
        }
    }
}
