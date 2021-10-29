using System;

namespace _03_Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            int fullCourses = numOfPeople / elevatorCapacity;
            int notFullCources = numOfPeople % elevatorCapacity;
            if (notFullCources!=0)
            {
                fullCourses++;
            }
            Console.WriteLine(fullCourses);
        }
    }
}
