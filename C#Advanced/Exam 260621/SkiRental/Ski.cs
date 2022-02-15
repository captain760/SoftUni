using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class Ski
    {
        public Ski(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Manufacturer);
            sb.Append(" - ");
            sb.Append(Model);
            sb.Append(" - ");
            sb.Append(Year);
            return sb.ToString().Trim();
        }
    }
}
