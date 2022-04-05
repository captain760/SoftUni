using CarRacing.Models;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;

using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Maps;
using CarRacing.Core.Contracts;

namespace CarRacing.Core
{ 
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private Map map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else throw new ArgumentException("Invalid car type!");
            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;
            var car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username,car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username,car);
            }
            else throw new ArgumentException("Invalid racer type!");
            
            racers.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.FindBy(racerOneUsername);
            var racerTwo = racers.FindBy(racerTwoUsername);
            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
           return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var racer in racers.Models.OrderByDescending(x=>x.DrivingExperience).ThenBy(x=>x.Username).ToList())
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
