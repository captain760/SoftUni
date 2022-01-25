namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";



            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string[] textLines = File.ReadAllLines(inputFilePath);
            int newLength = 0;
            if (textLines.Length % 2 == 0)
            {
                newLength = textLines.Length / 2;
            }
            else
            {
                newLength = textLines.Length / 2 + 1;
            }
            string[] evenLines = new string[newLength];
            int counter = 0;
            for (int i = 0; i < textLines.Length; i++)
            {
                if (i % 2 == 0)
                {
                    evenLines[counter] = textLines[i];
                    counter++;
                }

            }
            foreach (var item in evenLines)
            {
                string replaced = ReplaceSymbols(item);
                string reversed = ReverseWords(replaced);
                Console.WriteLine(reversed);
            }
            return null;
        }
        private static string ReverseWords(string replacedSymbols)
        {
            string[] words = replacedSymbols.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string reversedLine = null;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversedLine += words[i] + " ";
            }
            return reversedLine;
        }

        private static string ReplaceSymbols(string line)
        {
            char[] replacables = new char[] { '-', ',', '.', '!', '?' };
            StringBuilder sb = new StringBuilder();
            sb.Append(line);
            foreach (var symbol in replacables)
            {
                if (sb.ToString().Contains(symbol))
                {
                    sb.Replace(symbol, '@');
                }
            }
            return sb.ToString();

        }
    }

}
