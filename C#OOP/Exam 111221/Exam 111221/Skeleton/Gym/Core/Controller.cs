﻿using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName,motivation,numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            if ((athleteType == "Boxer" && gym.GetType().Name=="WeightliftingGym") || (athleteType == "Weightlifter" && gym.GetType().Name == "BoxingGym"))
            {
                return "The gym is not appropriate.";
            }
            gym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equip;
            if (equipmentType == "BoxingGloves")
            {
                equip = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equip = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            equipment.Add(equip);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName); 
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            double value = gym.EquipmentWeight;
            return $"The total weight of the equipment in the gym {gymName} is {value:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            var equip = equipment.FindByType(equipmentType);
            if (equip == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }            
            gym.AddEquipment(equip);
            equipment.Remove(equip);
            return $"Successfully added {equipmentType} to {gymName}.";            
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in gyms)
            {                
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
