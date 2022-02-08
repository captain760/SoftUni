using System;

namespace _03._Queue_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyQueue = new CustomQueue<int>();
            MyQueue.Enqueue(10);
            MyQueue.Enqueue(20);
            MyQueue.Enqueue(30);
            MyQueue.Enqueue(40);
            MyQueue.Enqueue(50);
            MyQueue.Enqueue(60);
            MyQueue.Dequeue();
            Console.WriteLine(MyQueue.Peek());
            Console.WriteLine(MyQueue.Peek());
            Console.WriteLine();
            MyQueue.ForEach(x => Console.WriteLine(x * 2));
            MyQueue.Clear();
            Console.WriteLine("emptying queue...");
            MyQueue.ForEach(x => Console.WriteLine(x * 2));
            Console.WriteLine("queue empty");
        }
    }
}
