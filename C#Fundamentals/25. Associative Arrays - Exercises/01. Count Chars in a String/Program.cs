using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> chars = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (chars.ContainsKey(input[i]))
                {
                    if (input[i] != ' ')
                    {
                        chars[input[i]]++;
                    }

                }
                else
                {
                    if (input[i] != ' ')
                    {
                        chars.Add(input[i], 1);
                    }

                }
            }
            foreach (var item in chars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
