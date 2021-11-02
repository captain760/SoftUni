using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class CatalogVehicle
    {

        public CatalogVehicle()
        {
            Cars = new List<Car>();        
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //List<Car> cars = new List<Car>();
            //List<Truck> trucks = new List<Truck>();
            //List<CatalogVehicle> vehicles = new List<CatalogVehicle>();
            CatalogVehicle kola = new CatalogVehicle();
            
            while (input != "end")
            {
                string[] data = input.Split("/");
                if (data[0] == "Car")
                {
                    Car currentCar = new Car()
                    {
                        Brand = data[1],
                        Model = data[2],
                        HorsePower = int.Parse(data[3])
                    };
                    
                    kola.Cars.Add(currentCar);
                }
                else
                {
                    Truck currentTruck = new Truck()
                    {
                        Brand = data[1],
                        Model = data[2],
                        Weight = int.Parse(data[3])
                    };
                    
                    kola.Trucks.Add(currentTruck);
                }

                input = Console.ReadLine();
            }
            //vehicles.Add(kola);
            
            var carsSortedList = kola.Cars.OrderBy(v => v.Brand);
            var trucksSortedList = kola.Trucks.OrderBy(v => v.Brand);

            Console.WriteLine("Cars:");
            foreach (var item in carsSortedList)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
            }
            Console.WriteLine("Trucks:");
            foreach (var item in trucksSortedList)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
            }
        }
    }
}
