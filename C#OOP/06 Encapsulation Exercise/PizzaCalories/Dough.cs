using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;        
        private Dictionary<string, double> nameMod = new Dictionary<string, double>
        {
            {"white" ,1.5 },
            {"wholegrain" ,1.0 },
            {"crispy" ,0.9 },
            {"chewy" ,1.1 },
            {"homemade" ,1.0 }
        };

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public double CaloriesPerGram 
        {
            get 
            {
                return 2*nameMod[flourType.ToLower()]*nameMod[bakingTechnique.ToLower()]; 
            }
            private set {; } 
        }
        private string FlourType
        {
            get { return flourType; }
            set 
            {
                try
                {
                    if (value.ToLower() !="white" && value.ToLower() != "wholegrain")
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(01);
                }
                flourType = value; 
            }
        }
        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set 
            {
                try
                {
                    if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(01);
                }
                bakingTechnique = value; 
            }
        }
        internal int Weight
        {
            get { return weight; }
            set 
            {
                try
                {
                    if (value <1 || value>200)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Dough weight should be in the range [1..200].");
                    Environment.Exit(01);
                }
                weight = value; 
            }
        }


    }
}
