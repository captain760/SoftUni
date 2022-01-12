using System;
using System.Collections.Generic;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> numbers = new Stack<int>();
            int startIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-')
                {
                    numbers.Push(int.Parse(input.Substring(startIndex, i - startIndex)));
                    startIndex = i + 1;
                }
                if (i == input.Length - 1)
                {
                    numbers.Push(int.Parse(input.Substring(startIndex, i - startIndex+1)));
                }
            }
            int sum = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == '+')
                {
                    sum += numbers.Pop();
                }
                else if (input[i] == '-')
                {
                    sum -= numbers.Pop();
                }
                else if (i==0)
                {
                    sum += numbers.Pop();
                }
            }
            Console.WriteLine(sum);
        }
    }
}
