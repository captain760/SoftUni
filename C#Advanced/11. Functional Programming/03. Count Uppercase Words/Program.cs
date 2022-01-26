using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allWords = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            Func<string, bool> isStartsWithUpper = n => char.IsUpper(n[0]);
            foreach (var word in allWords)
            {
                if (isStartsWithUpper(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
