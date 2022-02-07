using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private string date1;
        private string date2;
        public DateModifier(string first, string second)
        {
            Date1 = first;
            Date2 = second;
        }
        public string Date1 { get {return date1; } set {date1=value; } }
        public string Date2 { get {return date2; } set {date2=value; } }

        public System.TimeSpan DaysCalc(string first, string second)
        {
            DateTime firstDay =  DateTime.Parse(first);
            DateTime secondDay =  DateTime.Parse(second);
            return secondDay.Subtract(firstDay);
        }
    }
}
