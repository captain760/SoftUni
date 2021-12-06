using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> animalFood = new Dictionary<string, int>();
            Dictionary<string, string> animalArea = new Dictionary<string, string>();
            Dictionary<string, int> areaHungry = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input!="EndDay")
            {
                string[] cmd = input.Split(": ");
                if (cmd[0] == "Add")
                {
                    string[] token = cmd[1].Split("-");
                    string name = token[0];
                    int needfulFood = int.Parse(token[1]);
                    string area = token[2];
                    if (animalFood.ContainsKey(name))
                    {
                        animalFood[name] += needfulFood;
                    }
                    else
                    {
                        animalFood.Add(name, needfulFood);
                        
                        animalArea.Add(name, area);
                    }

                }
                else if (cmd[0]=="Feed")
                {
                    string[] token = cmd[1].Split("-");
                    string name = token[0];
                    int food = int.Parse(token[1]);
                    if (animalFood.ContainsKey(name))
                    {
                        if (animalFood[name] - food<=0)
                        {
                            Console.WriteLine($"{name} was successfully fed");
                            animalFood.Remove(name);
                            animalArea.Remove(name);
                            
                        }
                        else
                        {
                            animalFood[name] -= food;
                        }
                    }

                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Animals:");
            foreach (var animal in animalFood.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($" {animal.Key} -> {animal.Value}g");
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in animalArea)
            {
                if (areaHungry.ContainsKey(item.Value))
                {
                    areaHungry[item.Value]++;
                }
                else
                {
                    areaHungry.Add(item.Value, 1);
                }
            }
            foreach (var area in areaHungry.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($" {area.Key}: {area.Value}");
            }
        }
    }
}
