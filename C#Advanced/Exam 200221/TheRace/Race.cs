using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Racer Racer)
        {
            if (Count < Capacity)
            {
                data.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                data.Remove(data.Where(x => x.Name == name).First());
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Racer GetRacer(string name)
        {
            return data.Where(x => x.Name == name).FirstOrDefault();
        }
        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
