using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string> addSir = name =>
            {
                
                Console.WriteLine($"Sir {name}");
            };
            foreach (var item in names)
            {
                addSir(item);
            }
        }
    }
}
