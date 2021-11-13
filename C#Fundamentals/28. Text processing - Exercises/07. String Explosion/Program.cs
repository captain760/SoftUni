using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Explosions are marked with '>'.Immediately after the mark, there will be an integer, which signifies the strength of the explosion.
            //You should remove x characters(where x is the strength of the explosion), starting after the punch character('>').
            //If you find another explosion mark('>') while you’re deleting characters, you should add the strength to your previousexplosion.
            //When all characters are processed, print the string without the deletedcharacters. 
            //You should not delete the explosion character – '>', but you should delete the integers, which represent the strength.

            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                bool flag = false;
                
                if (input[i].ToString() == ">")
                {
                    result.Append(">");
                    strength += int.Parse(input[i + 1].ToString());
                    continue;
                }
                if (strength > 0 && input[i].ToString()!= ">")
                {
                    flag = true;
                    strength--;
                    continue;
                }
                if (!flag)
                {
                    result.Append(input[i]);
                }
                
            }
            Console.WriteLine(result);
        }
    }
}
