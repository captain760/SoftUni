using System;

namespace GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int Value = int.Parse(Console.ReadLine());
                var box = new Box<int>(Value);
                box.ToString();
            }
        }
    }
}
