using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get {return data.Count; } }
        public void Add(Ski ski)
        {
            if (this.Capacity> data.Count)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (data.Any(x=>x.Manufacturer == manufacturer) && data.Any(x => x.Model == model))
            {
               
                data.Remove(data.FirstOrDefault(x => x.Manufacturer == manufacturer &&  x.Model == model));
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().Trim();
        }
        
    }
}
