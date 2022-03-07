using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
        {            
            Name = name;
            Weight = weight;
            LivingRegion = livingRegion;
            Breed = breed;
        }

        public override string Breed { get ; set ; }
        public override string Name { get ; set ; }
        public override double Weight { get ; set ; }
        public override string LivingRegion { get; set ; }
        public override int FoodEaten { get ; set ; }
        public override string AskForFood()
        {
            return "Meow";
        }
        public override string ToString()
        {
            return $"Cat [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
