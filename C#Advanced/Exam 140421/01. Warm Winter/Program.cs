using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hatsArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int[] scarfsArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Stack<int> hats = new Stack<int>(hatsArray);
            Queue<int> scarfs = new Queue<int>(scarfsArray);
            List<int> sets = new List<int>();
            while (hats.Count>0 && scarfs.Count>0)
            {
                if (hats.Peek()>scarfs.Peek())
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (hats.Peek()<scarfs.Peek())
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    int newHatValue = hats.Pop()+1;
                    hats.Push(newHatValue);
                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
