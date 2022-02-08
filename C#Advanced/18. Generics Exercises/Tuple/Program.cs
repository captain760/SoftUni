using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = stringElements[0] + " " + stringElements[1];
            string address = stringElements[2];
            MyTuple<string, string> tuple1 = new MyTuple<string, string>(name, address);
            Console.WriteLine(tuple1.ToString());

            stringElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = stringElements[0];
            int liters = int.Parse(stringElements[1]);
            MyTuple<string, int> tuple2 = new MyTuple<string, int>(name, liters);
            Console.WriteLine(tuple2.ToString());

            stringElements = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int number = int.Parse(stringElements[0]);
            double number2 = double.Parse(stringElements[1]);
            MyTuple<int, double> tuple3 = new MyTuple<int, double>(number, number2);
            Console.WriteLine(tuple3.ToString());
        }
    }
}
