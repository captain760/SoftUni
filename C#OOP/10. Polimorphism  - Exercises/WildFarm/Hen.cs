using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen:Bird
    {
        public Hen(string name, double weight, double wingSize)
        {
            Name = name;
            Weight = weight;
            WingSize = wingSize;
        }

        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override double WingSize { get; set; }
        public override int FoodEaten { get; set; }
        public override string AskForFood()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
