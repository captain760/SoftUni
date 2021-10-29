using System;

namespace _11_MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
                int theInteger = int.Parse(Console.ReadLine());
                int multiplier = int.Parse(Console.ReadLine());
            if (multiplier>10)
            {
                Console.WriteLine($"{theInteger} X {multiplier} = {theInteger * multiplier}");
            }
            else
            {  
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{theInteger} X {i} = {theInteger * i}");
                }
            }
            
        }
    }

}