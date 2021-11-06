using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> namePlate = new Dictionary<string, string>();
            int numCmd = int.Parse(Console.ReadLine());
            for (int i = 0; i < numCmd; i++)
            {
                string[] input = Console.ReadLine().Split();
                string cmd = input[0];
                string name = input[1];
                string plate = null;
                if (input.Length == 3)
                {
                    plate = input[2];
                }
                
                if (cmd == "register")
                {
                    if (namePlate.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {namePlate[name]}");
                    }
                    else
                    {
                        namePlate.Add(name, plate);
                        Console.WriteLine($"{name} registered {plate} successfully");
                    }
                }
                else
                {
                    if (!namePlate.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        namePlate.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }
            foreach (var item in namePlate)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
