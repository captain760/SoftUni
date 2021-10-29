using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> set1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> set2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> merged = new List<int>();
            List<int> limited = new List<int>();
            int minLength = Math.Min(set1.Count, set2.Count);
            int limit1, limit2;
            for (int i = 0; i < minLength; i++)
            {
                
                    merged.Add(set1[i]);
                    merged.Add(set2[set2.Count - i-1]);
                
                
            }
            if (set1.Count>set2.Count)
            {
                 limit1 = set1[minLength];
                 limit2 = set1[minLength+1];
            }
            else
            {
                 limit1 = set2[0];
                 limit2 = set2[1];
            }
            if (limit1 > limit2)
            {
                int temp = limit1;
                limit1 = limit2;
                limit2 = temp;
            }
            for (int i = 0; i < merged.Count; i++)
            {
                if (merged[i]>limit1 && merged[i]<limit2)
                {
                    limited.Add(merged[i]);
                }
            }
            limited.Sort();
            Console.WriteLine(string.Join(" ",limited));
        }
    }
}
