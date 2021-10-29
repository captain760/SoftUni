using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int addBonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int maxAttendance = 0;
            for (int i = 0; i < students; i++)
            {
                int attendance = int.Parse(Console.ReadLine());
                double totalBonus = 1.0 * attendance / lectures * (5 + addBonus);
                if (totalBonus>maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendance = attendance;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
