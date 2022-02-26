using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(List<Product> bag, decimal money, string name)
        {
            Bag = new List<Product>();
            Money = money;
            Name = name;

        }

        public List<Product> Bag
        {
            get { return bag; }
            set { bag = value; }
        }


        public decimal Money
        {
            get { return money; }
            set 
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(01);
                }
                
                money = value; 
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
