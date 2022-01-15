using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                if (input[i] == ')' || input[i] == '}' || input[i] == ']')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        if ((input[i] == ')' && stack.Peek() == '(') || (input[i] == '}' && stack.Peek() == '{') || (input[i] == ']' && stack.Peek() == '['))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }


            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
