using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
        {
            Name = name;
            Weight = weight;
            WingSize = wingSize;
        }

        public override string Name { get ; set ; }
        public override double Weight { get ; set ; }
        public override double WingSize { get; set ; }
        public override int FoodEaten { get; set; }
        public override string AskForFood() 
        {
            return "Hoot Hoot";
        }
        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
