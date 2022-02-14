using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            participants = new List<Car>();
        }
        public List<Car> Participants => participants;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count { get {return participants.Count; }  }
        public void Add(Car car)
        {
            if (!participants.Any(x=>x.LicensePlate == car.LicensePlate))
            {
                if (this.Count< this.Capacity)
                {
                    if (car.HorsePower<=this.MaxHorsePower)
                    {
                        participants.Add(car);
                    }
                }
            }
        }
        public bool Remove(string licensePlate)
        {
            if (participants.Any(x => x.LicensePlate == licensePlate))
            {
                participants.Remove(participants.Where(x => x.LicensePlate == licensePlate).First());
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            if (participants.Any(x => x.LicensePlate == licensePlate))
            {
                return participants.Where(x => x.LicensePlate == licensePlate).First();
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            return participants.OrderByDescending(x=> x.HorsePower).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in participants)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
