using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Morse_code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {



            string morse = Console.ReadLine();

            Console.WriteLine(MorseCodeDecoder.Decode(morse));
        }
    }
    class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            morseCode = morseCode.Trim();
            List<string> morseWords = morseCode.Split(" | ").ToList();
            List<string> currentWord = new List<string>();
            string test = "";
            for (int i = 0; i < morseWords.Count; i++)
            {
                currentWord = morseWords[i].Split(" ").ToList();
                for (int j = 0; j < currentWord.Count; j++)
                {
                    test += MorseCode(currentWord[j]);
                }
                if (i != morseWords.Count - 1)
                {
                    test += " ";
                }

            }

            return test;
        }
        public static string MorseCode(string c1)
        {
            var MorseCode = new Dictionary<string, string>
            {
                { ".-", "A" },
                { "-...", "B"},
                { "-.-.", "C"},
                { "-..", "D"},
                { ".", "E"},
                { "..-.", "F"},
                { "--.", "G"},
                { "....", "H"},
                { "..", "I"},
                { ".---", "J"},
                { "-.-", "K"},
                { ".-..", "L"},
                { "--", "M"},
                { "-.", "N"},
                { "---", "O"},
                { ".--.", "P"},
                { "--.-", "Q"},
                { ".-.", "R"},
                { "...", "S"},
                { "-", "T"},
                { "..-", "U"},
                { "...-", "V"},
                { ".--", "W"},
                { "-..-", "X"},
                { "-.--", "Y"},
                { "--..", "Z"},
                { "-----", "0"},
                { ".----", "1"},
                { "..---", "2"},
                { "...--", "3"},
                { "....-", "4"},
                { ".....", "5"},
                { "-....", "6"},
                { "--...", "7"},
                { "---..", "8"},
                { "----.", "9"},
                { "", ""}
            };
            return MorseCode[c1];
        }
    }
}
