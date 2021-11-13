using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            StringBuilder repstr = new StringBuilder();
            foreach (var word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    repstr.Append(word);
                }
            }
            Console.WriteLine(repstr);
        }
    }
}
