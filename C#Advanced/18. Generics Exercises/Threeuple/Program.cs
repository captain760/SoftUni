using System;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = stringElements[0] + " " + stringElements[1];
            string address = stringElements[2];
            string town = stringElements[3];
            Threeuple<string, string,string> threeuple1 = new Threeuple<string, string, string>(name, address, town);
            Console.WriteLine(threeuple1.ToString());

            stringElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = stringElements[0];
            int liters = int.Parse(stringElements[1]);
            string drunk = stringElements[2];
            bool drunkenOrNot = false;
            if (drunk == "drunk")
            {
                drunkenOrNot = true;
            }
            Threeuple<string, int,bool> threeuple2 = new Threeuple<string, int,bool>(name, liters,drunkenOrNot);
            Console.WriteLine(threeuple2.ToString());

            stringElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = stringElements[0];
            double number = double.Parse(stringElements[1]);
            string bank = stringElements[2];
            Threeuple<string, double,string> threeuple3 = new Threeuple<string, double, string>(name, number,bank);
            Console.WriteLine(threeuple3.ToString());
        }
    }
}
