using System;
using System.Linq;
using System.Text;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();
            string input = Console.ReadLine();
            while (input!="END")
            {
                string[] cmd = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "Push")
                {
                    var sb = new StringBuilder();
                    for (int i = 1; i < cmd.Length; i++)
                    {
                        sb.Append(cmd[i]);
                    }
                    string numbers = sb.ToString().Trim();
                    int[] elements = numbers
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                    foreach (var item in elements)
                    {
                        myStack.Push(item);
                    }
                }
                else if (cmd[0] == "Pop")
                {
                    myStack.Pop();
                }
                input = Console.ReadLine();
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
