using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (wordSynonyms.ContainsKey(word))
                {
                    wordSynonyms[word].Add(synonym);
                }
                else
                {
                    List<string> synonyms = new List<string>();
                    synonyms.Add(synonym);
                    wordSynonyms.Add(word, synonyms);
                }
            }
            foreach (var item in wordSynonyms)
            {
                Console.Write(item.Key+" - ");
                Console.WriteLine(string.Join(", ", item.Value));
            }
        }
    }
}
