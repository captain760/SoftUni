using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get ; set ; }
        public string Birthday { get ; set; }
        public override string ToString()
        {
            return $"{Birthday}";
        }
    }
}
