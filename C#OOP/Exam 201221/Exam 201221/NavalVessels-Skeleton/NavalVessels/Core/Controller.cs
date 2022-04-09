using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;
        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            var vessel = vessels.FindByName(selectedVesselName);
            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (vessel.Captain!=null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = vessels.FindByName(attackingVesselName);
            var defender = vessels.FindByName(defendingVesselName);
            if (attacker == null )
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (defender == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            if (attacker.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defender.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }
            attacker.Attack(defender);
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defender.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
        var captain = new Captain(fullName);
            if (captains.Any(x=>x.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }
            captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name)!=null)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            IVessel vessel;
            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if(vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return "Invalid vessel type.";
            }
            vessels.Add(vessel);
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            
            if (vessel!=null && vessel.GetType().Name=="Battleship")
            {
                var battleshipVessel = vessel as Battleship;
                battleshipVessel.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else if (vessel != null && vessel.GetType().Name == "Submarine")
            {
                var submarineVessel = vessel as Submarine;
                submarineVessel.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
            else
            {
                return $"Vessel {vesselName} could not be found.";
            }
            
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            return vessel.ToString();
        }
    }
}
