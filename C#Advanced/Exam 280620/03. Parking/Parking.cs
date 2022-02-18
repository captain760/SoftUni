using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Car car)
        {
            if (Count<Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (data.Any(x=>x.Manufacturer == manufacturer && x.Model == model))
            {
                data.Remove(data.Where(x => x.Manufacturer == manufacturer && x.Model == model).First());
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer,string model)
        {
            return data.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
