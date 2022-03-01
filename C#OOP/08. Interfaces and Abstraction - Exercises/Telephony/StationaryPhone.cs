using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
