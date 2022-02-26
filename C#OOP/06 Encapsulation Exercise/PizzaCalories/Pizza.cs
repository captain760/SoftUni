using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private Topping topping;
        private List<Topping> toppings;
        private double totalCalories = 0 ;
        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }
        
        
        public string Name
        {
            get { return name; }
            set 
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value) || value.Length>15)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(01);
                }
                name = value; 
            }
        }
        public Dough Dough 
        {             
            set 
            {
               this.dough = value ;
            }
        }
        public double TotalCalories
        {
            get 
            {
                totalCalories =  dough.Weight*dough.CaloriesPerGram;
                for (int i = 0; i < toppings.Count; i++)
                {
                    totalCalories += toppings[i].Weight * toppings[i].CaloriesPerGram;
                }
                return totalCalories;
            }
            private set
            { 
                totalCalories = value; 
            }
        }
        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);
        }
        public int NumberOfToppings => toppings.Count;
        
    }
}
