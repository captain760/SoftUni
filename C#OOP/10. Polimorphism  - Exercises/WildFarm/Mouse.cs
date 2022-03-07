using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
        {
            Name = name;
            Weight = weight;
            LivingRegion = livingRegion;
        }

        public override string Name { get; set ; }
        public override double Weight { get; set ; }
        public override string LivingRegion { get ; set ; }
        public override int FoodEaten { get; set ; }
        public override string AskForFood()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
