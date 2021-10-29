using System;

namespace _05_PrintPartOfASCIItable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startCode = int.Parse(Console.ReadLine());
            int stopCode = int.Parse(Console.ReadLine());
            for (int i = startCode; i <= stopCode; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
