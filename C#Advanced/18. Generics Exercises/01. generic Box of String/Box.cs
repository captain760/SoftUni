﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public void ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Value.GetType());
            sb.Append(": ");
            sb.Append(Value);
            Console.WriteLine(sb.ToString().Trim()); 
        }
    }
}
