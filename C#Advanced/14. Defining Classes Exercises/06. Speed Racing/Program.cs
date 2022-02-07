using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Car> cars = new Dictionary<string, Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                Car car = new Car(model,fuelAmount,fuelConsumptionFor1km);
                cars.Add(model, car);
                
            }
            string token = Console.ReadLine();
            while (token!="End")
            {
                string[] cmd = token.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string carModel = cmd[1];
                int amountOfKm = int.Parse(cmd[2]);
                if (cars[carModel].IsDriving(amountOfKm))
                {
                    cars[carModel].FuelAmount -= cars[carModel].FuelConsumptionPerKilometer * amountOfKm;
                    cars[carModel].Travelleddistance += amountOfKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                token = Console.ReadLine();
            }
            foreach (var model in cars)
            {
                Console.WriteLine($"{model.Key} {model.Value.FuelAmount:f2} {model.Value.Travelleddistance}");
            }
        }
    }
}
