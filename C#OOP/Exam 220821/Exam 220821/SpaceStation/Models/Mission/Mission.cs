using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            IAstronaut currentAstronaut = astronauts.FirstOrDefault();
            while (astronauts.Count>0)
            {
                while (currentAstronaut.CanBreath)
                {
                    if (planet.Items.FirstOrDefault() != null)
                    {
                        string item = planet.Items.FirstOrDefault();
                        currentAstronaut.Breath();

                        currentAstronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        if (currentAstronaut.Oxygen == 0)
                        {
                            break;
                        }

                    }
                    else
                    {
                        break;
                    }

                }
                if (!currentAstronaut.CanBreath)
                {
                    astronauts.Remove(currentAstronaut);
                    currentAstronaut = astronauts.FirstOrDefault();
                }
                if (planet.Items.FirstOrDefault() == null)
                {
                    break;
                }
            }
           
        }
    }
}
