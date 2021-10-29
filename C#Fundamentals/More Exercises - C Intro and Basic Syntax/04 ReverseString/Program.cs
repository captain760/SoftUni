using System;

namespace _04_ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string normal = Console.ReadLine();
            int l = normal.Length;
            for (int i = (l-1); i >=0; i--)
            {
                Console.Write(normal[i]);
            }
        }
    }
}
