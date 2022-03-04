using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle:Shape
    {
        private double width;
        private double height;
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height 
        {        
            get { return this.height; }
            private set
            {
                if (value >= 0)
                {
                    this.height = value;
                }
            }
       
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value >= 0)
                {
                    this.width = value;
                }
            }

        }

        public override double CalculateArea()
        {
            return Height*Width;
        }

        public override double CalculatePerimeter()
        {
           return 2.0*(Width+Height);
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
