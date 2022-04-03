using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Workshops;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private int countColloredEggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
            bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.Models.Where(x => x.Name == bunnyName).FirstOrDefault();
            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            var dye = new Dye(power);
            bunny.Dyes.Add(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            Workshop workshop = new Workshop();
            var egg = eggs.FindByName(eggName);
            var sortedBunnies = bunnies.Models.OrderByDescending(x => x.Energy).TakeWhile(x => x.Energy >= 50);
            if (sortedBunnies==null)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            foreach (var bunny in sortedBunnies)
            {
                workshop.Color(egg, bunny);            
                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
                if (bunny.Dyes.Count==0)
                {
                    continue;
                }
                if (egg.IsDone())
                {
                    break;
                }
            }
            string eggState = "not done";
            if (egg.IsDone())
            {
                eggState = "done";
                //countColloredEggs++;
            }
            return $"Egg {eggName} is {eggState}.";
        }

        public string Report()
        {
            countColloredEggs = this.eggs.Models.Count();
            var sb = new StringBuilder();
            sb.AppendLine($"{countColloredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
