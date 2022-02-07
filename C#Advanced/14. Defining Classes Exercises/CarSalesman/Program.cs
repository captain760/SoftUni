using System;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            Engine[] engines = new Engine[numberOfEngines];
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                Engine engine = new Engine(model, power);
                if (input.Length == 3)
                {
                    int result = 0;
                    if (int.TryParse(input[2], out result))
                    {
                        int displacement = int.Parse(input[2]);
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = input[2];
                        engine.Efficiency = efficiency;
                    }
                    
                }
                if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    engine.Displacement = displacement;
                    string efficiency = input[3];
                    engine.Efficiency = efficiency;
                }
                engines[i] = engine;

            }
            int numberOfCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[numberOfCars];
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engineModel = input[1];
                Engine currentEngine = engines.Where(x => x.Model == engineModel).FirstOrDefault();
                Car car = new Car(model, currentEngine);
                if (input.Length ==3)
                {
                    int result = 0;
                    if (int.TryParse(input[2],out result))
                    {
                        int weight = int.Parse(input[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = input[2];
                        car.Color = color;
                    }
                                        
                }
                if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    car.Weight = weight;
                    string color = input[3];
                    car.Color = color;
                }
                cars[i] = car;

            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement!=0)
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                if (car.Engine.Efficiency != null)
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                if (car.Weight != 0)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                if (car.Color != null)
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($"  Color: n/a");
                }
            }
        }
    }
}
