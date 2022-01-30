using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> nums = new List<int>();
            Func<int, int, bool> isDevisable = (n, x) => n % x == 0;
            for (int i = 1; i <= n; i++)
            {
                bool devisibleByAll = true;
                foreach (var num in deviders)
                {
                    if (!isDevisable(i,num))
                    {
                        devisibleByAll = false;
                        break;
                    }
                }
                if (devisibleByAll)
                {
                    nums.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
