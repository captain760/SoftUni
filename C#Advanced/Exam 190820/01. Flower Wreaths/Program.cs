using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rosesElements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int[] liliesElements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Queue<int> roses = new Queue<int>(rosesElements);
            Stack<int> lilies = new Stack<int>(liliesElements);
            int wreaths = 0;
            int stored = 0;
            while (roses.Count>0 && lilies.Count>0)
            {
                int sum = roses.Peek() + lilies.Peek();
                if (sum==15)
                {
                    wreaths++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (sum>15)
                {
                    int newlilies = lilies.Pop() - 2;
                    lilies.Push(newlilies);
                    continue;
                }
                else
                {
                    stored += sum;
                    roses.Dequeue();
                    lilies.Pop();
                }
            }
            wreaths += stored / 15;
            if (wreaths>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
            }
        }
    }
}
