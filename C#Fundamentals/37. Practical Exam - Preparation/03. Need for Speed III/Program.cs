using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> carMileage = new Dictionary<string, int>();
            Dictionary<string, int> carFuel = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string name = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);
                carMileage.Add(name, mileage);
                carFuel.Add(name, fuel);
            }
            string token = Console.ReadLine();
            while (token!="Stop")
            {
                string[] cmd = token.Split(" : ");
                if (cmd[0] == "Drive")
                {
                    string car = cmd[1];
                    int distance = int.Parse(cmd[2]);
                    int gas = int.Parse(cmd[3]);
                    if (carFuel[car]<gas)
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    else
                    {
                        carMileage[car] += distance;
                        carFuel[car] -= gas;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {gas} liters of fuel consumed.");
                        if (carMileage[car]>=100000)
                        {
                            carFuel.Remove(car);
                            carMileage.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }


                }
                else if (cmd[0] == "Refuel")
                {
                    string car = cmd[1];
                    int gas = int.Parse(cmd[2]);
                    int fueled = 0;
                    if (carFuel[car]+gas>75)
                    {

                        fueled = 75 - gas;
                        carFuel[car] = 75;
                    }
                    else
                    {
                        carFuel[car] += gas;
                        fueled = gas;
                    }
                    Console.WriteLine($"{car} refueled with {fueled} liters");

                }
                else if (cmd[0] == "Revert")
                {
                    string car = cmd[1];
                    int kilometers = int.Parse(cmd[2]);
                    if ((carMileage[car] - kilometers)<10000)
                    {
                        carMileage[car] = 10000;
                    }
                    else
                    {
                        carMileage[car] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }


                }


                token = Console.ReadLine();
            }
            carMileage = carMileage.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var car in carMileage)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value} kms, Fuel in the tank: {carFuel[car.Key]} lt.");
            }
        }
    }
}
