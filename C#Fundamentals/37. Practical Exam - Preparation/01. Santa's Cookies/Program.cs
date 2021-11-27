using System;

namespace _01._Santa_s_Cookies
{
    class Program
    {
        static void Main(string[] args)
        {
            int batches = int.Parse(Console.ReadLine());
            int totalBoxes = 0;
            for (int i = 1; i <= batches; i++)
            {
                int flour = int.Parse(Console.ReadLine());
                int sugar = int.Parse(Console.ReadLine());
                int cocoa = int.Parse(Console.ReadLine());
                int boxes = 0;
                int totalCookies = 0;
                int floorCups = flour / 140;
                int sugarSpoons = sugar / 20;
                int cocoaSpoons = cocoa / 10;
                int min = 0;
                if (floorCups<sugarSpoons)
                {
                    if (floorCups<cocoaSpoons)
                    {
                        min = floorCups;
                    }
                    else
                    {
                        min = cocoaSpoons;
                    }
                }
                else if (sugarSpoons<cocoaSpoons)
                {
                    min = sugarSpoons;
                }
                else
                {
                    min = cocoaSpoons;
                }

                if (floorCups<=0 || sugarSpoons<=0 || cocoaSpoons<=0)
                {
                    Console.WriteLine($"Ingredients are not enough for a box of cookies.");
                }
                else
                {
                    totalCookies = (170*min)/25;
                    boxes = totalCookies / 5;
                    Console.WriteLine($"Boxes of cookies: {boxes}");
                    totalBoxes += boxes;
                }
            }
            Console.WriteLine($"Total boxes: {totalBoxes}");
        }
    }
}
