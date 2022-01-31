using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstInstance = new Car();
            Car secondInstance = new Car(make, model, year);
            Car thirdInstance = new Car(make, model, year, fuelQuantity, fuelConsumption);
            Console.WriteLine(firstInstance.Make);
            Console.WriteLine(secondInstance.Model);
            Console.WriteLine(thirdInstance.FuelQuantity);
        }
    }
}
