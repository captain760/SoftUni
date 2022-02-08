using System;

namespace _02._Stack_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyStack = new CustomStack<int>();
            MyStack.Push(10);
            MyStack.Push(20);
            MyStack.Push(30);
            MyStack.Push(40);
            MyStack.Push(50);
            MyStack.Pop();
            Console.WriteLine(MyStack.Peek());
            Console.WriteLine(MyStack.Peek());
            Console.WriteLine();
            MyStack.ForEach(x => Console.WriteLine(x*2));
        }
    }
}
