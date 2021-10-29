using System;

namespace _03._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            // You are given the coordinates of four points in the 2D plane.The first and the second pair of points form two
            //different lines. Print the longer line in format & quot; (X1, Y1)(X2, Y2) & quot; starting with the point that is closer to the center of
            //the coordinate system(0, 0)(You can reuse the method that you wrote for the previous problem).If the lines are of
            //equal length, print only the first one.
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            Console.WriteLine();
            if (LineLength(x1,y1,x2,y2)>=LineLength(x3,y3,x4,y4))
            {
                CenterPodouble(x1, y1, x2, y2); NotCenterPodouble(x1, y1, x2, y2);
            }
            else
            {
                CenterPodouble(x3, y3, x4, y4); NotCenterPodouble(x3, y3, x4, y4);
            }

        }

        private static void CenterPodouble(double x1, double y1, double x2, double y2)
        {
            
            if (Math.Sqrt(x1 * x1 + y1 * y1) <= Math.Sqrt(x2 * x2 + y2 * y2))
            {
                Console.Write($"({x1}, {y1})");
            }
            else
            {
                Console.Write($"({x2}, {y2})");
            }
        }

        private static void NotCenterPodouble(double x1, double y1, double x2, double y2)
        {

            if (Math.Sqrt(x1 * x1 + y1 * y1) > Math.Sqrt(x2 * x2 + y2 * y2))
            {
                Console.Write($"({x1}, {y1})");
            }
            else
            {
                Console.Write($"({x2}, {y2})");
            }
        }
        private static double LineLength(double x1, double y1, double x2, double y2)
        {

            double l = Math.Sqrt((x2 - x1) * (x2 - x1) - (y2 - y1) * (y2 - y1));
            return l;
        }
    }
}
