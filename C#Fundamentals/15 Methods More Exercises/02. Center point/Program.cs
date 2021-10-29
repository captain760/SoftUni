using System;

namespace _02._Center_podouble
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given the coordinates of two podoubles on a Cartesian coordinate system - X1, Y1, X2 and Y2.Create a method
            //that prdoubles the podouble that is closest to the center of the coordinate system(0, 0) in the format(X, Y). If the podoubles are
            //on a same distance from the center, prdouble only the first one.

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            CenterPodouble(x1, y1, x2, y2);
        }

        private static void CenterPodouble(double x1, double y1, double x2, double y2)
        {
            
            if (Math.Sqrt(x1*x1+y1*y1) <= Math.Sqrt(x2 * x2 + y2 * y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
