using System;

namespace _01_Data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that, depending on the first line of the input, reads an int, double or string.
            // If the data type is int, multiply the number by 2.
            // If the data type is real, multiply the number by 1.5 and format it to the second decimal point.
            // If the data type is string, surround the input with &quot;$&quot;.
            //Print the result on the console.
            string firstLine = Console.ReadLine();
            if (firstLine == "int")
            {
                int intInput = int.Parse(Console.ReadLine());
                DataTypes(intInput);
            }else if (firstLine == "real")
            {

                double realInput = double.Parse(Console.ReadLine());
                DataTypes(realInput);
            }else if (firstLine == "string")
            {
                string stringInput = Console.ReadLine();
                DataTypes(stringInput);
            }

        }

        private static void DataTypes(string secondLine)
        {
            secondLine = "$" + secondLine + "$";
            Console.WriteLine(secondLine);
        }

        private static void DataTypes(int secondLine)
        {
            Console.WriteLine(secondLine*2);
        }

        private static void DataTypes(double secondLine)
        {
            Console.WriteLine($"{(secondLine*1.5):f2}");
        }
    }
}
