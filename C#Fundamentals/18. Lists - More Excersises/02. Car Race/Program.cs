using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program to calculate the winner of a car race.You will receive an array of numbers.Each element of the
            //array represents the time needed to pass through that step(the index). There are going to be two cars.One of
            //them starts from the left side and the other one starts from the right side.The middle index of the array is the
            //finish line.The number of elements in the array will always be odd. Calculate the total time for each racer to reach
            //the finish, which is the middle of the array, and print the winner with his total time(the racer with less time).If
            //you have a zero in the array, you have to reduce the time of the racer that reached it by 20 % (from his current
            //time).
            //Print the result in the following format "The winner is { left / right } with total time: { total time}".
            List<int> race = Console.ReadLine().Split().Select(int.Parse).ToList();
            double leftSum = 0;
            double rightSum = 0;
            double winnerSum = 0;
            string winner = "";
            for (int i = 0; i < race.Count/2; i++)
            {
                if (race[i] != 0)
                {
                    leftSum += race[i];
                }
                else
                {
                    leftSum *= 0.8;
                }
                if (race[race.Count -i-1] != 0)
                {
                    rightSum += race[race.Count - i - 1];
                }
                else
                {
                    rightSum *= 0.8;
                }
            }
            if (leftSum>rightSum)
            {
                winner = "right";
                winnerSum = rightSum;
            }
            else
            {
                winner = "left";
                winnerSum = leftSum;
            }
            string winnerSumStr = winnerSum.ToString("0.######");
            Console.WriteLine($"The winner is {winner} with total time: {winnerSumStr}");
        }
    }
}
