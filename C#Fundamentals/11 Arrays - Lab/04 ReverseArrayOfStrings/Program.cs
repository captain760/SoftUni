using System;
using System.Linq;

namespace _04_ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Create a program that reads an array of strings, reverses it, and prints its elements.The input consists of a sequence
            //  of space-separated Strings.Print the output on a single line(space separated).
            string[] words = Console.ReadLine().Split().ToArray();
            string[] revWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                revWords[i] = words[words.Length - i - 1];
            }
            Console.WriteLine(string.Join(" ",revWords));
        }
    }
}
