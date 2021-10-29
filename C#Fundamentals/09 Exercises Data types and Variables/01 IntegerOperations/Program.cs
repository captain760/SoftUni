using System;

namespace _01_IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());
            int midSum = (firstNum + secondNum) / thirdNum;
            int finalSum = midSum * fourthNum;
            Console.WriteLine(finalSum);

        }
    }
}
