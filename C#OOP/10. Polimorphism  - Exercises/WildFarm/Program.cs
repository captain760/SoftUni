using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            string input = Console.ReadLine();
            while (input!="End")
            {
                string[] cmd = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = cmd[0];
                string name = cmd[1];
                double weight = double.Parse(cmd[2]);
                IAnimal animal = null;
                if (type == "Cat" )
                {
                    string livingRegion = cmd[3];
                    string breed = cmd[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    string livingRegion = cmd[3];
                    string breed = cmd[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
                else if (type == "Owl" )
                {
                    double wingSize = double.Parse(cmd[3]);
                    animal = new Owl(name, weight, wingSize);
                }
                else if (type == "Hen")
                {
                    double wingSize = double.Parse(cmd[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == "Mouse")
                {
                    string livingRegion = cmd[3];
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    string livingRegion = cmd[3];
                    animal = new Dog(name, weight, livingRegion);
                }

                string[] food = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = food[0];                
                int quantity = int.Parse(food[1]);
                Console.WriteLine(animal.AskForFood());
                if (animal is Hen)
                {
                    if (foodType != "Vegetable" && foodType != "Fruit" && foodType != "Meat" && foodType != "Seeds")
                    {
                        Console.WriteLine($"Hen does not eat {foodType}!");
                        animals.Add(animal);
                        input = Console.ReadLine();
                        continue;
                    }
                    animal.FoodEaten += quantity;
                    animal.Weight += quantity * 0.35;
                }
                else if (animal is Owl || animal is Dog || animal is Tiger)
                {
                    if (foodType != "Meat")
                    {
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                        animals.Add(animal);
                        input = Console.ReadLine();
                        continue;
                    }
                    animal.FoodEaten += quantity;
                    if (animal is Owl)
                    {
                        animal.Weight += quantity * 0.25;
                    }
                    else if (animal is Dog)
                    {
                        animal.Weight += quantity * 0.4;
                    }
                    else if (animal is Tiger)
                    {
                        animal.Weight += quantity * 1.0;
                    }

                }
                else if (animal is Mouse)
                {
                    if (foodType != "Vegetable" && foodType != "Fruit")
                    {
                        Console.WriteLine($"Mouse does not eat {foodType}!");
                        animals.Add(animal);
                        input = Console.ReadLine();
                        continue;
                    }
                    animal.FoodEaten += quantity;
                    animal.Weight += quantity * 0.10;
                }
                else if (animal is Cat)
                {
                    if (foodType != "Vegetable" && foodType != "Meat")
                    {
                        Console.WriteLine($"Cat does not eat {foodType}!");
                        animals.Add(animal);
                        input = Console.ReadLine();
                        continue;
                    }
                    animal.FoodEaten += quantity;
                    animal.Weight += quantity * 0.3;
                }
                animals.Add(animal);
                input = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
