using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> drones = new List<Drone>();
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;          
        }
        public IReadOnlyCollection<Drone> Drones => drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return Drones.Count; } }
        public string AddDrone(Drone drone)
        {
            if (drone.Name==null || drone.Brand == null || drone.Range<5 || drone.Range>15)
            {
                return"Invalid drone.";                
            }
            if (Capacity==Count)
            {
                return"Airfield is full.";                
            }
                drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";           
        }
        public bool RemoveDrone(string name)
        {
            
            if (drones.Any(x => x.Name == name))
            {
                Drone toRemove = drones.First(x => x.Name == name);
                drones.Remove(toRemove);
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            
            int removedCount = drones.Count(x => x.Brand == brand);
            drones.RemoveAll(x => x.Brand == brand);
            return removedCount;
            
        }
        public Drone FlyDrone(string name)
        {           
            if (drones.Any(x => x.Name == name))
            {
                Drone drone = drones.First(x => x.Name == name);
                drone.Available = false;
                return drone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> GreaterRangeDrones = drones.FindAll(x => x.Range >= range);          
            GreaterRangeDrones.Select(x => x.Available = false).ToList();            
            return GreaterRangeDrones;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            for (int i = 0; i < this.Count; i++)
            {
                if (drones[i].Available)
                {
                    sb.AppendLine(drones[i].ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
