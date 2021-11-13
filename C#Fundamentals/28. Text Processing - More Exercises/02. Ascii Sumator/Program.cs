using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that prints a sum of all characters between two given characters(their ascii code). On the first line you will get a character.On the second line you get another character. On the last line you get a random string.Find all the characters between the two given and print their ascii sum.
            char first = char.Parse(Console.ReadLine());
            char last = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > first && input[i] < last)
                {
                    sum += input[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
