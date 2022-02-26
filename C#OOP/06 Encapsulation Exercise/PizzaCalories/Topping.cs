using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;        
        private int weight;
        private Dictionary<string, double> nameMod = new Dictionary<string, double>
        {
            {"meat" ,1.2 },
            {"veggies" ,0.8 },
            {"cheese" ,1.1 },
            {"sauce" ,0.9 }            
        };

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;            
            Weight = weight;
        }

        public double CaloriesPerGram
        {
            get
            {
                return 2 * nameMod[toppingType.ToLower()];
            }
            private set {; }
        }
        private string ToppingType
        {
            get { return toppingType; }
            set
            {
                try
                {
                    if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(01);
                }
                toppingType = value;
            }
        }
       
        internal int Weight
        {
            get { return weight; }
            set
            {
                try
                {
                    if (value < 1 || value > 50)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"{toppingType} weight should be in the range [1..50].");
                    Environment.Exit(01);
                }
                weight = value;
            }
        }
    }
}
