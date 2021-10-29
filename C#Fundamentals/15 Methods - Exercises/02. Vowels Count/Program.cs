using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that receives a single string and prints out the number of vowels contained in it.
            string input = Console.ReadLine();
            VowelsCount(input);
        }

        private static void VowelsCount(string input)
        {
            string vowels = "aeiouAEIOU";
            int vowelsCount = 0;
            foreach (char item in vowels)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (item == input[i])
                    {
                        vowelsCount++;
                    }
                }
            }
            Console.WriteLine(vowelsCount);
        }
    }
}
