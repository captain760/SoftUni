﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyVallidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj!=null)
            {
                return true;
            }
            return false;
        }
    }
}
