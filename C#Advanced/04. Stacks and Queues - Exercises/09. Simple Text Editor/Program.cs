using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split().ToArray();
                if (cmd[0] == "1")
                {
                    if (stack.Count > 0)
                    {
                        stack.Push(stack.Peek() + cmd[1]);
                    }
                    else
                    {
                        stack.Push(cmd[1]);
                    }

                }
                else if (cmd[0] == "2")
                {
                    stack.Push(stack.Peek().Substring(0, stack.Peek().Length - int.Parse(cmd[1])));
                }
                else if (cmd[0] == "3")
                {
                    int index = int.Parse(cmd[1]) - 1;
                    Console.WriteLine(stack.Peek().Substring(index, 1));
                }
                else if (cmd[0] == "4")
                {
                    stack.Pop();
                }
            }
        }
    }
}
