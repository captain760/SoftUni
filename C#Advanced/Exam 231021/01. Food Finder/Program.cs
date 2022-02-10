using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> consonants = new Stack<char>();
            Queue<char> vowels = new Queue<char>();
            Dictionary<string, char[]> wordsLetters = new Dictionary<string, char[]>();
            wordsLetters.Add("pear", new char[4]);
            wordsLetters.Add("flour", new char[5]);
            wordsLetters.Add("pork", new char[4]);
            wordsLetters.Add("olive", new char[5]);
            char[] vow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            foreach (var item in vow)
            {
                vowels.Enqueue(item);
            }
            char[] con = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            foreach (var item in con)
            {
                consonants.Push(item);
            }
            while (consonants.Count!=0)
            {
                char vowel = vowels.Dequeue();
                vowels.Enqueue(vowel);
                char consonant = consonants.Pop();
                foreach (var item in wordsLetters)
                {
                    for (int i = 0; i < item.Key.Length; i++)
                    {
                        if (item.Key[i] == vowel)
                        {
                            item.Value[i] = vowel;
                        }
                        if (item.Key[i] == consonant)
                        {
                            item.Value[i] = consonant;
                        }
                    }
                }
            }
            int fullWords = 0;
            List<string> foundWords = new List<string>();
            foreach (var item in wordsLetters)
            {
                bool isNotFull = false;
                for (int i = 0; i < item.Value.Length; i++)
                {
                    if (item.Value[i] == 0)
                    {
                        isNotFull = true;
                        break;
                    }
                }
                if (isNotFull)
                {
                    continue;
                }
                foundWords.Add(item.Key);
                fullWords++;
            }
            Console.WriteLine($"Words found: {fullWords}");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
