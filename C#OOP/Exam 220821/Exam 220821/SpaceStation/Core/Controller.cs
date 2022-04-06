using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private IMission mission;
        private int exploredPlanetsCount;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astro;
            if (type == "Biologist")
            {
                astro = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astro = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astro = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astronauts.Add(astro);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }
            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            List<IAstronaut> chosenAstronauts = astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            int totalChosen = chosenAstronauts.Count;
            if (totalChosen == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            mission.Explore(planet, chosenAstronauts);
            exploredPlanetsCount++;
            return $"Planet: {planetName} was explored! Exploration finished with {totalChosen - chosenAstronauts.Count} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count==0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ",astronaut.Bag.Items)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if (astronaut==null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
