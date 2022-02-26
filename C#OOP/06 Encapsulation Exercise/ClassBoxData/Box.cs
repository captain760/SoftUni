using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    length = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Length cannot be zero or negative.");
                    return;
                }

            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    width = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Width cannot be zero or negative.");
                    return;
                }
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    height = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Height cannot be zero or negative.");
                    return;
                }
            }
        }
        public double SurfaceArea()
        {
            return 2 * (Width * Length + Width * Height + Length * Height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (Width * Height + Length * Height);
        }
        public double Volume()
        {
            return Length * Width * Height;
        }
    }
}
