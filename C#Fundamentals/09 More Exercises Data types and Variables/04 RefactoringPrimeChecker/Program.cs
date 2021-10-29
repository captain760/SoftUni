using System;

namespace _04_RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNum = int.Parse(Console.ReadLine());
            for (int currentNum = 2; currentNum <= endNum; currentNum++)
{
                bool isNotPrime = true;
                for (int devisor = 2; devisor < currentNum; devisor++)
{
                    if (currentNum % devisor == 0)
                    {
                        isNotPrime = false;
                        break;
                    }
                }
                if (isNotPrime)
                {
                    Console.WriteLine($"{currentNum} -> true");
                }
                else
                {
                    Console.WriteLine($"{currentNum} -> false" +
                        $"");
                }
            }
        }
    }
}
