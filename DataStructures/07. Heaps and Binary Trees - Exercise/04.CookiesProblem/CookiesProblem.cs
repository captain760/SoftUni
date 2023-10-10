using System;
using System.Linq;

using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();
            priorityQueue.AddMany(cookies);
            var currentMinSweetnes = priorityQueue[0];
            int steps = 0;

            while (currentMinSweetnes<minSweetness && priorityQueue.Count>1)
            {
                int leastSweetCookie = priorityQueue.RemoveFirst();
                int secondSweetCookie = priorityQueue.RemoveFirst();

                int newCookie = leastSweetCookie + 2 * secondSweetCookie;
                priorityQueue.Add(newCookie);
                currentMinSweetnes = priorityQueue[0];
                steps++;
            }
            return currentMinSweetnes<minSweetness ? -1 : steps;
        }
    }
}
