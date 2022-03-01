using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IDentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthday = birthdate;
        }

        public string Id { get ; set ; }
        public string Name { get; set; }
        public int Age { get; set; }        
        public string Birthday { get ; set ; }

        public override string ToString()
        {
            return $"{Birthday}";
        }
    }
}
