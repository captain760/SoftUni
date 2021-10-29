using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a method that receives two numbers and an operator, calculates the result and returns it. You will be given
            //three lines of input. The first will be the first number, the second one will be the operator and the last one will be
            //the second number.
            //The possible operators are: /, *, +and -.
            int firstNum = int.Parse(Console.ReadLine());
            string operat = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculator(firstNum,operat,secondNum));

        }
        private static double Calculator(int a, string operat, int b)
        {
            double result = 0;
            switch (operat)
            {
                case "/":
                    {
                        result = a / b;
                        break;
                    }
                case "*":
                    {
                        result = a * b;
                        break;
                    }
                case "+":
                    {
                        result = a + b;
                        break;
                    }
                case "-":
                    {
                        result = a - b;
                        break;
                    }
                default:
                    break;
            }
            return result;
        }
    }
}
