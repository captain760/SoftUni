using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(decimal price, string name)
        {
            Price = price;
            Name = name;
        }

        public decimal Price
        {
            get { return price; }
            set 
            {
                try
                {
                    if (value<0)
                    {
                        throw new Exception();                        
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(01);
                }
                price = value;
            }
        }


        public string Name
        {
            get { return name; }
            set 
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(01);
                }
                name = value; 
            }
        }
        
    }
}
