﻿using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var car = carRepository.FindByName(carModel);
            var pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.Car!=null)
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");
            }
            if (car==null)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }
            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot { pilotName } will drive a {car.GetType().Name} { carModel } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var pilot = pilotRepository.FindByName(pilotFullName);
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName} to the race.");
            }
            race.AddPilot(pilot);
            return $"Pilot { pilotFullName} is added to the { raceName } race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = carRepository.FindByName(model);
            if (car!=null)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            carRepository.Add(car);
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            var pilot = pilotRepository.FindByName(fullName);
            if (pilot!=null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            IPilot newPilot = new Pilot(fullName);
            pilotRepository.Add(newPilot);
            return $"Pilot { fullName } is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race != null)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }
            IRace newRace = new Race(raceName, numberOfLaps);
            raceRepository.Add(newRace);
            return $"Race { raceName } is created.";
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            foreach (var race in raceRepository.Models)
            {
                if (race.TookPlace)
                {
                    sb.AppendLine(race.RaceInfo().ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if (race.Pilots.Count<3)
            {
                throw new InvalidOperationException($"Race { raceName } cannot start with less than three participants.");
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");
            }
            List<IPilot> pilots = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();
            race.TookPlace = true;
            pilots[0].WinRace();

            var sb = new StringBuilder();
            sb.AppendLine($"Pilot {pilots[0].FullName} wins the { raceName } race.");
            sb.AppendLine($"Pilot {pilots[1].FullName} is second in the { raceName } race.");
            sb.AppendLine($"Pilot { pilots[2].FullName} is third in the { raceName } race.");
            return sb.ToString().TrimEnd();

        }
    }
}
