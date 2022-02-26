using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pizzaName = string.Empty;
            string[] pizzaElements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (pizzaElements.Length>1)
            {
                pizzaName = pizzaElements[1];
            }            
            Pizza pizza = new Pizza(pizzaName);
            input = Console.ReadLine();
            string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int doughWeight = int.Parse(cmd[3]);
            Dough dough = new Dough(cmd[1], cmd[2], doughWeight);
            pizza.Dough = dough;
            input = Console.ReadLine();
            while (input != "END")
            {
                string[] token = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int weight = int.Parse(token[2]);
                Topping topping = new Topping(token[1], weight);
                pizza.AddTopping(topping);
                input = Console.ReadLine();
            }

            try
            {
                if (pizza.NumberOfToppings > 10 )
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Number of toppings should be in range [0..10].");
                Environment.Exit(01);
            }
            Console.WriteLine($"{pizzaName} - {pizza.TotalCalories:f2} Calories.");
        }
    }
}
