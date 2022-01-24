using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Dictionary<int, int> numbersTimes = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                
                if (!numbersTimes.ContainsKey(num))
                {
                    numbersTimes.Add(num, 0);
                }
                numbersTimes[num]++;
            }
            foreach (var num in numbersTimes)
            {
                if (num.Value%2==0)
                {
                    Console.WriteLine(num.Key);
                    return;
                }
            }

        }
    }
}
