using System;

namespace _04._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //In the &quot; Tribonacci & quot; sequence, every number is formed by the sum of the previous 3.
            //You are given a number num. Write a program that prints num numbers from the Tribonacci sequence, each on a
            //new line, starting from 1.The input comes as a parameter named num.The value num will always be positive integer.
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Tribonacci(num);
        }

        private static void Tribonacci(int num)
        {
            int counter = 4;
            if (num == 1)
            {
                Console.Write("1");
            }
            else if (num == 2)
            {
                Console.Write("1 1");
            }
            else if (num == 3)
            {
                Console.Write("1 1 2");
            }
            else
            {

                Console.Write("1 1 2 ");
                int tribonachi = 4;
                int prev = 2;
                int prevprev = 1;
                int prevprevprev = 1;
                while (counter <= num)
                {
                    tribonachi = prev + prevprev + prevprevprev;
                    prevprevprev = prevprev;
                    prevprev = prev;
                    prev = tribonachi;
                    counter++;
                    Console.Write(tribonachi + " ");
                }
            }
        }
    }
}
