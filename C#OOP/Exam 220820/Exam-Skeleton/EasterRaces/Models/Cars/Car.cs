using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int maxHorsePower;
        private int minHorsePower;
        private double cubicCentimeters;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.maxHorsePower = maxHorsePower;
            this.minHorsePower = minHorsePower;
        }
        public string Model 
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,model,4));
                }
                model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return horsePower;
            }
            private set
            {
                if (value>=maxHorsePower&& value<=minHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                horsePower = value;
            }
        }
        public double CubicCentimeters 
        {
            get { return cubicCentimeters; }
            private set {cubicCentimeters = value; }
        }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
