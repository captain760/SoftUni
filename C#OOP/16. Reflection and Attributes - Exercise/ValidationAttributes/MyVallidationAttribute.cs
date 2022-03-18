using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    public abstract class MyVallidationAttribute:Attribute
    {
        public abstract bool IsValid(object obj);
       
    }
}
