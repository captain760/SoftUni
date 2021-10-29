using System;

namespace _01_SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double n3 = double.Parse(Console.ReadLine());
            double x1, x2, x3, k;

            x1 = n1;
            x2 = n2;
            x3 = n3;
            while (x1 < x2 || x2 < x3)
            {
                if (x3 >= x2)
                {
                    k = x3;
                    x3 = x2;
                    x2 = k;
                }
                if (x2 >= x1)
                {
                    k = x2;
                    x2 = x1;
                    x1 = k;

                }
            }
            Console.WriteLine(x1);
            Console.WriteLine(x2);
            Console.WriteLine(x3);
        }
    }
}
