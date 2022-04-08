using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class Gym : IGym
    {
        private string name;
        
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => equipments.Sum(x=>x.Weight);

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity==athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            else
            {
                athletes.Add(athlete);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (athletes.Count==0)
            {
                sb.AppendLine($"Athletes: No athletes");
            }
            else
            {
                sb.AppendLine($"Athletes: {string.Join(", ",athletes.Select(x=>x.FullName))}");
            }
            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
