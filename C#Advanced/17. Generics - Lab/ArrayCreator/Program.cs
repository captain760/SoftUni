using System;
using System.Collections.Generic;

namespace GenericArrayCreator
{
    public class StartUp
    { 
        public static void Main(string[] args)
        {
            
            var stringArray = ArrayCreator.Create<string>(5, "gogo");
           var integerArray = ArrayCreator.Create<int>(4, 6);
        }
    }
}
