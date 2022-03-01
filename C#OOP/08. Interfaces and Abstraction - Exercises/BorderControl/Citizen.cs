using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IDentifiable
    {
        public Citizen(string name, int age, string id)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get ; set ; }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
