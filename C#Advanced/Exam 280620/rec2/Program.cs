using System;

namespace rec2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = Fact(n);
            Console.WriteLine(result);
        }

        private static int Fact(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return n * Fact(n - 1);
        }
    }
}
