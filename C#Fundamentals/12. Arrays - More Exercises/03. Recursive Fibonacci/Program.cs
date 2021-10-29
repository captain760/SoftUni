using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibIndex = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(fibIndex));

        }
        static int Fib(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
