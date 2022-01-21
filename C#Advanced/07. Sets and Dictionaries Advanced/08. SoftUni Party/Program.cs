using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();
            bool partyTime = false;
            while (input!= "END")
            {
                if (input!="PARTY" && partyTime == false)
                {
                    if (char.IsDigit(input,0))
                    {
                        vipGuests.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }
                }
                else if (partyTime==false)
                {
                    partyTime = true;
                    input = Console.ReadLine();
                    continue;
                }
                if (partyTime)
                {
                    if (char.IsDigit(input, 0))
                    {
                        if (vipGuests.Contains(input))
                        {
                            vipGuests.Remove(input);
                        }
                        
                    }
                    else
                    {
                        if (regularGuests.Contains(input))
                        {
                            regularGuests.Remove(input);

                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(vipGuests.Count+regularGuests.Count);
            if (vipGuests.Count > 0)
            {
                foreach (var guest in vipGuests)
                {
                    Console.WriteLine(guest);
                }
            }
            if (regularGuests.Count>0)
            {
                foreach (var guest in regularGuests)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
