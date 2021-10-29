using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a method that receives two characters and prints all the characters between them according to ASCII(on a
            //single line).
            //NOTE: If the second letter&#39;s ASCII value is less than that of the first one then the two initial letters should be
            //swapped.
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            CharactersInRange(first, second);

        }

        private static void CharactersInRange(char first, char second)
        {
            if (first>second)
            {
                char temp = first;
                first = second;
                second = temp;
            }
            for (int i = (int)first+1; i < (int)second; i++)
            {
                Console.Write((char)i+" ");
            }
        }
    }
}
