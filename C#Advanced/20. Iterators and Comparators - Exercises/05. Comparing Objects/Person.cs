using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Comparing_Objects
{
    public class Person:IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name)>0)
            {
                return 1;
            }
            else if (this.Name.CompareTo(other.Name)<0)
            {
                return -1;
            }
            else
            {
                if (this.Age > other.Age)
                {
                    return 1;
                }
                else if (this.Age < other.Age)
                {
                    return -1;
                }
                else
                {
                    if (this.Town.CompareTo(other.Town)>0)
                    {
                        return 1;
                    }
                    else if (this.Town.CompareTo(other.Town)<0)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
