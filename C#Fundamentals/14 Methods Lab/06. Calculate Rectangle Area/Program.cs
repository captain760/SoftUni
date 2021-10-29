using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double area = AreaCalc(width, length);
            Console.WriteLine(area);
        }
        static double AreaCalc(double width, double length)
        {
            return width * length;
        }
    }
}
