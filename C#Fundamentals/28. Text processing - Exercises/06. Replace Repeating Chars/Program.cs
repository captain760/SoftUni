using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a string from the console and replaces any sequence of the same letters with a singlecorresponding letter.
            string input = Console.ReadLine();
            //StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] == input[i+1])
                {
                    input = input.Remove(i + 1, 1);
                    i--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
