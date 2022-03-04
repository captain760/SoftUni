using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape figure = new Rectangle(4.2, 5.3);
            Console.WriteLine($"{figure.Draw():f2}");
            Console.WriteLine($"{figure.CalculatePerimeter():f2}");
            Console.WriteLine($"{figure.CalculateArea():f2}");
            figure = new Circle(6.8);
            Console.WriteLine($"{figure.Draw():f2}");
            Console.WriteLine($"{figure.CalculatePerimeter():f2}");
            Console.WriteLine($"{figure.CalculateArea():f2}");
        }
    }
}
