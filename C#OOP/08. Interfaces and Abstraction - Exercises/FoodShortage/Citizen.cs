using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthday = birthdate;
            Food = 0;
        }

        public string Id { get ; set ; }
        public string Name { get; set; }
        public int Age { get; set; }        
        public string Birthday { get ; set ; }
        public int Food { get ; set; }

        public void BuyFood()
        {
            Food += 10;
        }

        public override string ToString()
        {
            return $"{Birthday}";
        }
    }
}
