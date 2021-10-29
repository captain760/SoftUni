using System;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string item = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine($"{TotalPrice(item, quantity):f2}");
        }
        static double TotalPrice(string item, int quantity)
        {
            double total = 0;
            switch (item)
            {
                case "coffee":
                    {
                        total = quantity * 1.5;
                        break;
                    }
                case "coke":
                    {
                        total = quantity * 1.4;
                        break;
                    }
                case "water":
                    {
                        total = quantity * 1.0;
                        break;
                    }
                case "snacks":
                    {
                        total = quantity * 2.0;
                        break;
                    }
                default:
                    break;
            }
            return total;
        }
    }
}
