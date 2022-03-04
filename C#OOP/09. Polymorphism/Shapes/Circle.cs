using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get {return this.radius; }
            private set 
            {
                if (value>=0)
                {
                    this.radius = value;
                }
            } 
        }
       

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI*Radius;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
