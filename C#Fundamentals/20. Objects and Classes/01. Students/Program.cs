using System;

namespace _01._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {

                int temp = rnd.Next(words.Length);
                string randWord = words[temp];
                words[temp] = words[i];
                words[i] = randWord;
            }
            Console.WriteLine(string.Join("\n", words));

        }
    }
}
