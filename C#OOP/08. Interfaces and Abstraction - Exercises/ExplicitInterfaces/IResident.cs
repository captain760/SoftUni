using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get; set; }
        public int Age { get; set; }
        string GetName();

    }
}
