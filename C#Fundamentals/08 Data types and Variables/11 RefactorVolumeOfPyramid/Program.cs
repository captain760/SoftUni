using System;

namespace _11_RefactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");

            double baseLength = double.Parse(Console.ReadLine());

            Console.Write("Width: ");

            double baseWidth = double.Parse(Console.ReadLine());

            Console.Write("Height: ");

            double hight = double.Parse(Console.ReadLine());

            double Volume = baseLength * baseWidth * hight / 3;

            Console.WriteLine($"Pyramid Volume: {Volume:f2}");
        }
    }
}
