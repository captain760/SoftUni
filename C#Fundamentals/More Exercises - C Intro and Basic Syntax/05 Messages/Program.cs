using System;

namespace _05_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = ' ';
            string word = "";
            int simbols = int.Parse(Console.ReadLine());
            for (int i = 0; i < simbols; i++)
            {           
            string code = Console.ReadLine();
            int l = code.Length;
            char firstFigure = code[0];
            int mainDigit = (int)(firstFigure-'0');
            int offset = (mainDigit - 2) * 3;
            if (mainDigit == 8 || mainDigit == 9)
            {
                offset++;
            }
            int letterIndex = offset + l - 1;
            letter = (char)(97 + letterIndex);
            if (letter == '[')
            {
                letter = ' ';
            }
                word += letter;
            }
            Console.WriteLine(word);
        }
    }
}
