using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double consumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            Consumption = consumption;
            TankCapacity = tankCapacity;
        }

        public abstract double FuelQuantity { get; set; }
        public abstract double Consumption { get; set; }
        public abstract double TankCapacity { get; set; }
        public abstract void Drive(double distance);
        public virtual void DriveEmpty(double distance)
        {

        }

        public abstract void Refuel(double fuel);
       
    }
}
