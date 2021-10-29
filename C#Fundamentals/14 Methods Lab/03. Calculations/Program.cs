using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that receives a string on the first line(add, multiply, subtract, divide) and, on the next two lines,
            //receives two numbers.Create four methods(for each calculation) and invoke the corresponding method depending
            //on the command.The method should also print the result(needs to be void).
            string mathAction = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            if (mathAction == "add")
            {
                Add(firstNum, secondNum);
            }
            else if (mathAction == "multiply")
            {
                Multiply(firstNum, secondNum);
            }
            else if (mathAction == "subtract")
            {
                Subtract(firstNum, secondNum);
            }
            else if (mathAction == "divide")
            {
                Divide(firstNum, secondNum);
            }
            
        }
        static void Add(int a, int b)
        {
            Console.WriteLine(a+b);
            return;
        }
        static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
            return;
        }
        static void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
            return;
        }
        static void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
            return;
        }
    }
}
