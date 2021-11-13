using System;
using System.Linq;
using System.Text;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;

            foreach (var word in input)
            {
                StringBuilder numStr = new StringBuilder();
                for (int i = 1; i < word.Length-1; i++)
                {
                    numStr.Append(word[i]);
                }
                double number = int.Parse(numStr.ToString());
                double result = 0;
                if (Char.IsLower(word[0]))
                {
                    result = LetterPosition(word[0]) * number;
                }
                else
                {
                    result = number / LetterPosition(word[0]);
                }
                if (Char.IsLower(word[word.Length-1]))
                {
                    result += LetterPosition(word[word.Length-1]);
                }
                else
                {
                    result -= LetterPosition(word[word.Length-1]);
                }
                totalSum += result;
            }
            Console.WriteLine($"{totalSum:f2}");
        }

        private static int LetterPosition(char v)
        {
            if (Char.IsUpper(v))
            {
                return v - 64;
            }
            else
            {
                return v - 96;
            }
            
        }
    }
}
