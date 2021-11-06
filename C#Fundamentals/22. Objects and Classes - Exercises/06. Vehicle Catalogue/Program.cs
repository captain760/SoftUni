using System;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Hp { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Vehicle> vehicles = new List<Vehicle>();
            while (input!="End")
            {
                string[] token = input.Split();
                Vehicle currentVehicle = new Vehicle();
                if (token[0] == "car")
                {
                    token[0] = "Car";
                }
                else
                {
                    token[0] = "Truck";
                }
                currentVehicle.Type = token[0];
                currentVehicle.Model = token[1];
                currentVehicle.Color = token[2];
                currentVehicle.Hp = int.Parse(token[3]);
                vehicles.Add(currentVehicle);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "Close the Catalogue")
            {
                foreach (var item in vehicles)
                {
                    if (item.Model == input)
                    {
                        Console.WriteLine($"Type: {item.Type}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.Hp}");
                    }
                }
                
                input = Console.ReadLine();
            }
            int sumHpCars = 0;
            int numCars = 0;
            int sumHpTrucks = 0;
            int numTrucks = 0;
            foreach (var item in vehicles)
            {
                if (item.Type == "Car")
                {
                    sumHpCars += item.Hp;
                    numCars++;
                }
                else
                {
                    sumHpTrucks += item.Hp;
                    numTrucks++;
                }
            }
            double averageCars = 0;
            if (numCars != 0)
            {
               averageCars = 1.0 * sumHpCars / numCars;
            }
            double averageTrucks = 0;
            if (numTrucks!=0)
            {
                averageTrucks = 1.0 * sumHpTrucks / numTrucks;
            }
            
            Console.WriteLine($"Cars have average horsepower of: {averageCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucks:f2}.");
        }
    }
}
