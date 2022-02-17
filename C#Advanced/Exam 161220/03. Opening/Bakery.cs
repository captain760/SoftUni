using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get {return data.Count; }  }
        public void Add(Employee employee)
        {
            if (data.Count<Capacity)
            {
                data.Add(employee);
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
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            return data.Where(x => x.Name == name).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }            
            return sb.ToString().Trim();
        }
    }
}
