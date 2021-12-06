using System;

namespace _01_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            string input = Console.ReadLine();
            string result = "";
            while (input!="Abracadabra")
            {
                string[] token = input.Split();
                if (token[0] == "Abjuration")
                {
                    result = spell.ToUpper();
                    Console.WriteLine(result);
                }
                else if (token[0] == "Necromancy")
                {
                    result = spell.ToLower();
                    Console.WriteLine(result);
                }
                else if (token[0] == "Illusion")
                {
                    int index = int.Parse(token[1]);
                    char letter = char.Parse(token[2]);
                    if (index<0 || index>=spell.Length)
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                    else 
                    {
                        result = ReplaceAtIndex(index, letter, spell);
                        Console.WriteLine("Done!");
                    }
                }
                else if (token[0] == "Divination")
                {
                    string firstSub = token[1];
                    string secondSub = token[2];
                    if (spell.Contains(firstSub))
                    {
                        result = spell.Replace(firstSub, secondSub);
                        Console.WriteLine(result);
                    }
                }
                else if (token[0] == "Alteration")
                {
                    string sub = token[1];
                    if (spell.Contains(sub))
                    {
                        result = spell.Remove(spell.IndexOf(sub),sub.Length);
                        Console.WriteLine(result);
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
                spell = result;
                input = Console.ReadLine();
            }
        }
        static string ReplaceAtIndex(int i, char value, string word)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join("", letters);
        }
    }
}
