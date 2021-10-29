using System;

namespace _01_Pyrva
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            while (input != "END")
            { 
                string dataType = "";
                //long num;
                //double drob;
                bool otherType = false;
                                        
                bool result = long.TryParse(input,out _);
                if ((result || input == "0") && !otherType)
                {
                    dataType = "integer";
                    otherType = true;
                }
                result = double.TryParse(input, out _);
                if (result && !otherType)
                {
                    dataType = "floating point";
                    otherType = true;
                }
                if (input.Length == 1 && !otherType)
                {
                    dataType = "character";
                    otherType = true;
                }
                else if (input == "")
                {
                    dataType = "character";
                    otherType = true;
                }
                if (input.ToLower() == "true" || input.ToLower() == "false")
                {
                    dataType = "boolean";
                    otherType = true;
                }
                if (!otherType)
                {
                    dataType = "string";
                }
                Console.WriteLine($"{input} is {dataType} type");
                input = Console.ReadLine();
            } 
        }
    }
}
