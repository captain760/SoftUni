using System;

namespace _06_StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int numP = int.Parse(num);
            int sum = 0;
            int l = num.Length;
            int fact = 1;
            for (int i = 0; i <= (l-1); i++)
            {
                for (int j = 1; j <= (num[i]-48); j++)
                {
                    fact = fact * j;
                }
                sum += fact;
                fact = 1;
            }
            if (numP == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
