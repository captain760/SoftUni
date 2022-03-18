using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties()
                .Where(x=>x.GetCustomAttributes(typeof(MyVallidationAttribute)).Any())
                .ToArray();
            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(obj);
                var attribute = propertyInfo.GetCustomAttribute<MyVallidationAttribute>();
                bool isValid = attribute.IsValid(value);
                if (!isValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
