using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"The number {num} is {Sign(num)}.");
        }
        static string Sign(int n)
        {
            string s;
            if (n>0)
            {
                s = "positive";
            }
            else if (n<0)
            {
                s = "negative";
            }
            else
            {
                s = "zero";
            }
            return s;
        }
    }
}
