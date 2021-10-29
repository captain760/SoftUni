using System;

namespace _09_PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double ammountNeeded = 0;
            double totalLightsaber = 0;
            double totalRobes = 0;
            double totalBelts = 0;
            double freeBelts = 0;
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice= double.Parse(Console.ReadLine());
            totalLightsaber = Math.Ceiling(students * 1.1) * lightsaberPrice;
            totalRobes = students * robePrice;
            freeBelts = Math.Floor(students / 6.0);
            totalBelts = (students - freeBelts) * beltPrice;
            ammountNeeded = totalBelts + totalLightsaber + totalRobes;
            if (ammountNeeded<=money)
            {
                Console.WriteLine($"The money is enough - it would cost {ammountNeeded:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(ammountNeeded-money):f2}lv more.");
            }
        }
    }
}
