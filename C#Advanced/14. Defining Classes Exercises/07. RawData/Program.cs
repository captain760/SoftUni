using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> listCars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine engine = new Engine(engineSpeed, enginePower);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);
                Tire[] tires = new Tire[4];

                tires[0] = new Tire(tire1Age, tire1Pressure);
                tires[1] = new Tire(tire2Age, tire2Pressure);
                tires[2] = new Tire(tire3Age, tire3Pressure);
                tires[3] = new Tire(tire4Age, tire4Pressure);
                

                
                Car car = new Car(model, engine, cargo, tires);
                listCars.Add(car);
            }
            string cmd = Console.ReadLine();
            if (cmd == "fragile")
            {
                foreach (var vehicle in listCars.Where(x=>x.Cargo.Type == "fragile"))
                {
                    bool tireFlat = false;
                    for (int j = 0; j < 4; j++)
                    {
                        if (vehicle.Tires[j].Pressure<1)
                        {
                            tireFlat=true;
                            break;
                        }
                    }
                    if (tireFlat)
                    {
                        Console.WriteLine(vehicle.Model);
                    }
                }
            }
            if (cmd == "flammable")
            {
                foreach (var vehicle in listCars.Where(x=>x.Engine.Power>250))
                {
                    Console.WriteLine(vehicle.Model);
                }
            }
        }
    }
}
