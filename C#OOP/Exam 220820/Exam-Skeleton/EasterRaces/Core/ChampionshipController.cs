using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Repositories;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!driverRepository.Models.Any(x=>x.Name==driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (! carRepository.Models.Any(x=>x.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            var car = carRepository.GetByName(carModel);
            driverRepository.GetByName(driverName).AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!raceRepository.Models.Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (!driverRepository.Models.Any(x => x.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            
            var driver = driverRepository.GetByName(driverName);
            raceRepository.GetByName(raceName).AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.Models.Any(x=>x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            ICar car = null;
            if (type=="Muscle")
            {
                 car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                 car = new SportsCar(model, horsePower);
            }
            carRepository.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.Models.Any(x=>x.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            var driver = new Driver(driverName);
            driverRepository.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            var race = new Race(name, laps);
            raceRepository.Models.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (!raceRepository.Models.Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (raceRepository.GetByName(raceName).Drivers.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }
            var winners = raceRepository.GetByName(raceName).Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(this.raceRepository.GetByName(raceName).Laps)).Take(3).ToList();
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, raceName));
            raceRepository.Remove(raceRepository.GetByName(raceName));
            return sb.ToString().TrimEnd();
        }
    }
}
