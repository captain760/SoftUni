using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int lowerBound = range[0];
            int upperBound = range[1];
            string condition = Console.ReadLine();
            List<int> toPrint = new List<int>();
            Predicate<string> oddChecker = n => n == "odd";
            Predicate<string> evenChecker = n => n == "even";
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (oddChecker(condition))
                {
                    if (Math.Abs(i%2)==1)
                    {
                        toPrint.Add(i);
                    }
                    
                }
                if(evenChecker(condition))
                {
                    if (i%2==0)
                    {
                        toPrint.Add(i);
                    }
                }
            }
            Console.WriteLine(string.Join(" ",toPrint));
        }
    }
}
