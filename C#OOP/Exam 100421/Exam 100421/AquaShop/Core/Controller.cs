using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decor;
            if (decorationType == "Ornament")
            {
               decor = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decor = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            decorations.Add(decor);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);               
            }
            else if (fishType == "SaltwaterFish")           
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);                
            }
            else
            {               
                throw new InvalidOperationException($"Invalid fish type.");
            }
            if ((aquarium.GetType().Name == "FreshwaterAquarium" && fish.GetType().Name == "FreshwaterFish") || (aquarium.GetType().Name == "SaltwaterAquarium" && fish.GetType().Name == "SaltwaterFish"))
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return "Water not suitable.";
            }
            
               
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            decimal value = 0;
            foreach (var item in aquarium.Decorations)
            {
                value += item.Price;
            }
            foreach (var item in aquarium.Fish)
            {
                value += item.Price;
            }
            return $"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            if (decorations.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            IDecoration decor = decorations.FindByType(decorationType);
            aquarium.AddDecoration(decor);
            decorations.Remove(decor);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var item in aquariums)
            {
                sb.AppendLine(item.GetInfo().ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
