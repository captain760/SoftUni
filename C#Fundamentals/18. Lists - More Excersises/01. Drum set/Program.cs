using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Drum_set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initDrumSet = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> currentDrumSet = new List<int>();
            for (int i = 0; i < initDrumSet.Count; i++)
            {
                currentDrumSet.Add(initDrumSet[i]);
            }
            string input = Console.ReadLine();
            while (input != "Hit it again, Gabsy!")
            {
                int power = int.Parse(input);
                for (int i = 0; i < currentDrumSet.Count; i++)
                {
                    currentDrumSet[i] -= power;
                    if (currentDrumSet[i]<=0 && initDrumSet[i]*3>savings)
                    {
                        currentDrumSet.RemoveAt(i);
                        initDrumSet.RemoveAt(i);
                        i--;
                    }
                    else if(currentDrumSet[i]<=0 && initDrumSet[i]*3<savings)
                    {
                        currentDrumSet[i] = initDrumSet[i];
                        //if (savings > initDrumSet[i] * 3)
                        //{
                            savings -= initDrumSet[i] * 3;
                        //}
                        //else
                        //{
                        //    break;
                        //}
                        
                    }
                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",currentDrumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
