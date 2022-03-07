using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck:Vehicle
    {
        
        public Truck(double fuelQuantity, double consumption, double tankCapacity) : base(fuelQuantity, consumption, tankCapacity)
        {
            FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            Consumption = consumption;
            TankCapacity = tankCapacity;
        }

        public override double FuelQuantity { get; set; }
        public override double Consumption { get; set; }
        

        public override double TankCapacity { get; set; }



        public override void Drive(double distance)
        {

            double requiredFuel = distance * (Consumption + 1.6);
            if (FuelQuantity >= requiredFuel)
            {
                FuelQuantity -= requiredFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if (fuel > this.TankCapacity - this.FuelQuantity)
                {
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                }
                else
                {
                    FuelQuantity += 0.95*fuel;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
