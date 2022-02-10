using System.Text;

namespace Drones
{
    public class Drone
    {
        
        private bool available;
        public Drone(string name, string brand,int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get { return available; } set {available = value; } }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drone: {Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.AppendLine($"Range: {Range} kilometers");
            return sb.ToString().Trim();
        }
    }
}
