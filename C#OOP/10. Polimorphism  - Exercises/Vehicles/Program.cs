using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carElements[1]), double.Parse(carElements[2]), double.Parse(carElements[3]));
            
                        
            string[] truckElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckElements[1]), double.Parse(truckElements[2]), double.Parse(truckElements[3]));
            
            
            string[] busElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busElements[1]), double.Parse(busElements[2]), double.Parse(busElements[3]));
            
            

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "Drive")
                {
                    if (cmd[1] == "Car")
                    {
                        car.Drive(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Drive(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.Drive(double.Parse(cmd[2]));
                    }
                }
                else if (cmd[0] == "Refuel")
                {
                    if (cmd[1] == "Car")
                    {
                        car.Refuel(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(cmd[2]));
                    }
                }
                else if (cmd[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(cmd[2]));
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
