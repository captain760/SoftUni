using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Tire[]> tiresList = new List<Tire[]>();
            while (input != "No more tires")
            {                
                string[] token = input.Split();
                int tire1Year = int.Parse(token[0]);
                double tire1Pressure = double.Parse(token[1]);
                int tire2Year = int.Parse(token[2]);
                double tire2Pressure = double.Parse(token[3]); 
                int tire3Year = int.Parse(token[4]);
                double tire3Pressure = double.Parse(token[5]); 
                int tire4Year = int.Parse(token[6]);
                double tire4Pressure = double.Parse(token[7]);
                var currentSetTires = new Tire[4];
                Tire currentTire1 = new Tire(tire1Year, tire1Pressure);
                Tire currentTire2 = new Tire(tire2Year, tire2Pressure);
                Tire currentTire3 = new Tire(tire3Year, tire3Pressure);
                Tire currentTire4 = new Tire(tire4Year, tire4Pressure);
                currentSetTires[0] = currentTire1;
                currentSetTires[1] = currentTire2;
                currentSetTires[2] = currentTire3;
                currentSetTires[3] = currentTire4;
                tiresList.Add(currentSetTires);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            List<Engine> enginesList = new List<Engine>();
            while (input!="Engines done")
            {
                string[] token = input.Split();
                int horsePower = int.Parse(token[0]);
                double cubicCapacity = double.Parse(token[1]);
                Engine currentEngine = new Engine(horsePower, cubicCapacity);
                enginesList.Add(currentEngine);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            List<Car> carsList = new List<Car>();
            while (input!="Show special")
            {
                string[] token = input.Split();
                string make = token[0];
                string model = token[1];
                int year = int.Parse(token[2]);
                double fuelQuantity = double.Parse(token[3]);
                double fuelConsumption = double.Parse(token[4]);
                int engineIndex = int.Parse(token[5]);
                int tiresIndex = int.Parse(token[6]);
                Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, enginesList[engineIndex], tiresList[tiresIndex]);
                carsList.Add(currentCar);
                input = Console.ReadLine();
            }
            foreach (var car in carsList)
            {
                if (car.Year>=2017 && car.Engine.HorsePower>330 && car.Tires.Sum(x=>x.Pressure)>9 && car.Tires.Sum(x => x.Pressure) <10) 
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
