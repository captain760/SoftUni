using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;       
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }
        

        public int Count => this.fish.Count;

        public int Comfort => decorations.Sum(x=>x.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity>this.Count)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            sb.Append("Fish: ");
            if (Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                var fishNames = fish.Select(x => x.Name);
                sb.AppendLine(string.Join(", ", fishNames));
            }
            sb.AppendLine($"Decorations: { decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            //sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            //if (this.fish.Count == 0)
            //{
            //    sb.AppendLine("Fish: none");
            //}
            //else
            //{
            //    sb.Append("Fish: ");
            //    sb.AppendLine(string.Join(", ", this.fish.Select(x => x.Name)));
            //}
            //sb.AppendLine($"Decorations: {this.decorations.Count}");
            //sb.Append($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
