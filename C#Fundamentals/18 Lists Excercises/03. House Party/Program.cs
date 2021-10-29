using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a program that keeps track of the guests that are going to a house party. On the first line of input, you are
            // going to receive the number of commands that will follow.
            //On the next lines, you are going to receive some of the following: &quot;
            //            { name} is going!&quot;
            // You have to add the person if they are not in the guest list already.
            // If the person is on the list print to the following to the console: &quot;
            //            { name} is already in the list!&quot;
            //            &quot;
            //            { name} is not going!&quot;
            // You have to remove the person if they are in the list.
            // If not, print out: &quot;
            //            { name} is not in the list!&quot;
            //            Finally, print all of the guests, each on a new line.
            int numOfComands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for (int i = 0; i < numOfComands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string name = command[0];
                if (command[2] == "going!")
                {
                    if (!guests.Contains(name))
                    {
                        guests.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
                else if (command[2] == "not")
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
