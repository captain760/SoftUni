using System.Data.Common;
using System.Threading.Tasks;

namespace _01.Microsystem
{
    public class Computer
    {
        public Computer(int number, Brand brand, double price, double screenSize, string color)
        {
            this.Number = number;
            this.RAM = 8;
            this.Brand = brand;
            this.Price = price;
            this.ScreenSize = screenSize;
            this.Color = color;
        }
        public int Number { get; set; }

        public int RAM { get; set; }

        public Brand Brand { get; set; }

        public double Price { get; set; }

        public double ScreenSize { get; set; }

        public string Color { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Computer;

            if (other == null || other.Number != this.Number)
            {
                return false;
            }

            return true;
        }
        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
