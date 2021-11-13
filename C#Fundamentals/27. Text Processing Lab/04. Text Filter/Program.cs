using System;
using System.Text;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a program that takes a text and a string of banned words. All words included in the ban list should be replaced with asterisks "*", equal to the word's length. The entries in the ban list will be separated by a comma and space ", ".
            //The ban list should be entered on the first input line and the text on the second input line.
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            
            foreach (var word in bannedWords)
            {
                StringBuilder mask = new StringBuilder();
                for (int i = 0; i < word.Length; i++)
                {
                    mask.Append("*");
                }          
                text = text.Replace(word, mask.ToString());
                
            }
            Console.WriteLine(text);
        }
    }
}
