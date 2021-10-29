using System;

namespace _12_EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            while (number%2!=0)
            {
                Console.WriteLine("Please write an even number.");
                number = int.Parse(Console.ReadLine());
                number = Math.Abs(number);
            }
            Console.WriteLine($"The number is: {number}");
        }
    }
}
