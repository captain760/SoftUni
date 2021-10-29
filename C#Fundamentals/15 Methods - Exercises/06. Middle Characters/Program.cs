using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            //You will receive a single string.Create a method that prints the character found at its middle. If the length of the
            //string is even there are two middle characters.
            string str = Console.ReadLine();
            PrintMiddle(str);
        }

        private static void PrintMiddle(string str)
        {
            int middle = str.Length / 2;
            if (str.Length%2 ==0)
            {
                Console.WriteLine($"{str[middle-1]}{str[middle]}");
            }
            else
            {
                Console.WriteLine(str[middle]);
            }
        }
    }
}
