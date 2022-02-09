using System.Collections.Generic;
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
            List<Drone> drones = new List<Drone>();
        }
        public IReadOnlyCollection<Drone> Drones => drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return Drones.Count; } }
        public string AddDrone(Drone drone)
        {
            if (drone.Name==null || drone.Brand == null || drone.Name==string.Empty || drone.Brand == string.Empty || drone.Range<=5 || drone.Range>=15)
            {
                return"Invalid drone.";
                
            }
            else if (this.Capacity==this.Count)
            {
                return"Airfield is full";
                
            }
            else
            {
                drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
            
        }
        public bool RemoveDrone(string name)
        {
            int index = 0;
            bool isExisting = false;
            for (int i = 0; i < Drones.Count; i++)
            {
                if (drones[i].Name == name)
                {
                    isExisting = true;
                    index = i;
                    break;
                }
            }            
            if (isExisting)
            {
                drones.RemoveAt(index);
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int removedCount = 0;
            int initCount = this.Count;
            //for (int i = 0; i < initCount; i++)
            //{
            //    if (drones[i].Brand == brand)
            //    {
            //        drones.RemoveAt(i);
            //        removedCount++;
            //        i--;
            //    }
            //}
            int i = 0;
            while (i!= this.Count)
            {
                if (drones[i].Brand==brand)
                {
                    drones.RemoveAt(i);
                    removedCount++;
                    i--;
                }
                i++;
            }
            return removedCount;
        }
        public Drone FlyDrone(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (drones[i].Name == name)
                {
                    drones[i].Available = false;
                    return drones[i];
                }
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> GreaterRangeDrones = new List<Drone>();
            for (int i = 0; i < this.Count; i++)
            {
                if (drones[i].Range>=range)
                {
                    drones[i].Available = false;
                    GreaterRangeDrones.Add(drones[i]);
                }
            }
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
