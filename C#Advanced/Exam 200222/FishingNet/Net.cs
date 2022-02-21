using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }
        public List<Fish> Fish => fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get {return fish.Count; } }
        public string AddFish(Fish fish)
        {
            if (fish.Length>0 && fish.Weight>0 && string.IsNullOrWhiteSpace(fish.FishType)==false )
            {
                if (Count<Capacity)
                {
                    Fish.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";
                }
                else
                {
                    return "Fishing net is full.";
                }
            }
            else
            {
                return "Invalid fish.";
            }
        }
        public bool ReleaseFish(double weight)
        {
            if (Fish.Any(x=>x.Weight == weight))
            {
                Fish.Remove(Fish.Where(x => x.Weight == weight).First());
                return true;
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            return Fish.Where(x => x.FishType == fishType).FirstOrDefault();
        }
        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(x => x.Length).First();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var item in Fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
