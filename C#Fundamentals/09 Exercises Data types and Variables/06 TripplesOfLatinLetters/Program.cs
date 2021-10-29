using System;

namespace _06_TripplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= n; k++)
                    {
                        Console.WriteLine($"{(char)(96+i)}{(char)(96+j)}{(char)(96+k)}");
                    }
                }
            }
        }
    }
}
