using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Browse(string address)
        {
            return $"Browsing: {address}!";  
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
