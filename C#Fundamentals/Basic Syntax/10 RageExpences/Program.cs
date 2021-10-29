using System;

namespace _10_RageExpences
{
    class Program
    {
        static void Main(string[] args)
        {
            int games = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double brokenHeadsets = Math.Floor(games/2.0);
            double brokenMouses = Math.Floor(games/3.0);
            double brokenKeyboards = Math.Floor(games/6.0);
            double brokenDisplays = Math.Floor(games/12.0);
            double expenses = brokenHeadsets * headsetPrice + brokenMouses * mousePrice + brokenKeyboards * keyboardPrice + brokenDisplays * displayPrice;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
