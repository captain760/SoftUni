using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        public abstract override string Name { get; set; }
        public abstract override double Weight { get; set; }
        public abstract override string LivingRegion { get; set; }
        public abstract override int FoodEaten { get; set; }
        public abstract string Breed { get; set; }
    }
}
