using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that takes two strings as arguments and returns the sum of their character codesmultiplied(multiply str1[0] with str2[0] and add to the total sum). Then continue with the next two characters.If one of the strings is longer than the other, add the remaining character codes to the totalsum without multiplication.
            string[] input = Console.ReadLine().Split();
            string first = input[0];
            string second = input[1];
            int sum = CodesMultiplier(first, second);
            Console.WriteLine(sum);
        }

        private static int CodesMultiplier(string first, string second)
        {
            int sum = 0;
            int minLength = Math.Min(first.Length, second.Length);
            for (int i = 0; i < minLength; i++)
            {
                sum += first[i] * second[i];
            }
            if (first.Length>second.Length)
            {
                for (int i = second.Length; i < first.Length; i++)
                {
                    sum += first[i];
                }
            }
            else if (first.Length < second.Length)
            {
                for (int i = first.Length; i < second.Length; i++)
                {
                    sum += second[i];
                }
            }

            return sum;
        }
    }
}
