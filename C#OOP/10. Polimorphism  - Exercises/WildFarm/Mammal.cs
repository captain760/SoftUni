﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : IAnimal
    {
        public abstract string Name { get; set; }
        public abstract double Weight { get; set; }
        public abstract string LivingRegion { get; set; }
        public abstract int FoodEaten { get; set; }
        public abstract string AskForFood();
    }
}
