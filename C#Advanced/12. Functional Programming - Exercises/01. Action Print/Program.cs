using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string> printNL = name =>
            {
                Console.WriteLine(name);
            };
            foreach (var item in names)
            {
                printNL(item);
            }
        }
    }
}
