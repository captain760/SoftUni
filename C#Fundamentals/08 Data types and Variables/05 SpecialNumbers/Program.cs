using System;

namespace _05_SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                int restFigure = i;
                int lastFigure = i;
                int sum = 0;
                while (restFigure != 0)
                {
                    lastFigure = restFigure % 10;
                    restFigure -= lastFigure;
                    restFigure = restFigure / 10;
                    sum += lastFigure;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }

            }
        }
    }
}
