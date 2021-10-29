using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.Parse(Console.ReadLine());
            Triangle(maxNum);
        }
        static void PrintLine(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }
            return;
        }
        static void Triangle(int point)
        {
            for (int i = 1; i <= point; i++)
            {
               PrintLine(i);
                Console.WriteLine();
            }
            for (int i = point - 1; i > 0; i--)
            {
                PrintLine(i);
                Console.WriteLine();
            }
            return;
        }
    }
}
