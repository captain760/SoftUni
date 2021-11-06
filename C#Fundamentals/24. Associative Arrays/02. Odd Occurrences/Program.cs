using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split().ToArray();
            SortedDictionary<string, int> wordsOccurances = new SortedDictionary<string, int>();
            foreach (var item in words)
            {
                if (wordsOccurances.ContainsKey(item))
                {
                    wordsOccurances[item]++;
                }
                else
                {
                    wordsOccurances.Add(item, 1);
                }
            }
            List<string> finalWords = new List<string>();
            foreach (var item in words)
            {
                if (wordsOccurances[item]%2==1 && !finalWords.Contains(item))
                {
                    finalWords.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ",finalWords));
           
        }
    }
}
