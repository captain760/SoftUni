using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
     public class Circle: IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            for (int i = 0; i <= radius*2; i++)
            {
                for (int j = 0; j <= radius*2; j++)
                {
                    double distance = Math.Sqrt((radius - i) * (radius - i) + (radius - j) * (radius - j));
                    if (radius==Math.Ceiling(distance))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
