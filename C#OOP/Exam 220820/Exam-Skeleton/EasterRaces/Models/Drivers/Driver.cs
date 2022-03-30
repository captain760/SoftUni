using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate;
        private int winRace;

        public Driver(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
            this.winRace = 0;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, name, 5));
                }
                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate 
        {
            get
            {
                return canParticipate;
            }
            private set
            {
                if (this.Car != null)
                {
                    canParticipate = true;
                }
                else
                {
                    canParticipate = false;
                }

            }
        }

        public void AddCar(ICar car)
        {
            if (car==null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            winRace++;
        }
    }
}
