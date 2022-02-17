using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count { get {return data.Count; } }
        public void Add(Pet pet)
        {
            if (Capacity>Count)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            if (data.Any(x=>x.Name == name))
            {
                data.Remove(data.Where(x => x.Name == name).First());
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            return data.Where(x => x.Name == name && x.Owner == owner).FirstOrDefault();
        }
        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().Trim();
        }
    }
}
