using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in phoneNumbers)
            {
                if (number.All(x=>char.IsDigit(x)))
                {
                    if (number.Length == 10)
                    {
                        ICalling smartphone = new Smartphone();
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else if (number.Length == 7)
                    {
                        ICalling stationary = new StationaryPhone();
                        Console.WriteLine(stationary.Call(number)); ;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var address in websites)
            {
                if (!address.Any(x=>char.IsDigit(x)))
                {
                    IBrowsing website = new Smartphone();
                    Console.WriteLine(website.Browse(address)); ;
                }
                else Console.WriteLine("Invalid URL!");
            }
        }
    }
}
