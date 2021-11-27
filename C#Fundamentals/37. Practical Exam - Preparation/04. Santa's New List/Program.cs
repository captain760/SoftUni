using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Santa_s_New_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> childrenPoints = new Dictionary<string, int>();
            Dictionary<string, int> typeAmmount = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] token = input.Split("->");
                if (token[0] == "Remove")
                {
                    string badKid = token[1];
                    if (childrenPoints.ContainsKey(badKid))
                    {
                        childrenPoints.Remove(badKid);
                    }
                }
                else
                {
                    string name = token[0];
                    string typePresent = token[1];
                    int ammount = int.Parse(token[2]);
                    if (childrenPoints.ContainsKey(name))
                    {
                        childrenPoints[name] += ammount;
                    }
                    else
                    {
                        childrenPoints.Add(name, ammount);
                    }
                    if (typeAmmount.ContainsKey(typePresent))
                    {
                        typeAmmount[typePresent] += ammount;
                    }
                    else
                    {
                        typeAmmount.Add(typePresent, ammount);
                    }
                }


                input = Console.ReadLine();
            }
            Console.WriteLine("Children:");
            foreach (var kid in childrenPoints.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kid.Key} -> {kid.Value}");
            }
            Console.WriteLine("Presents:");
            foreach (var present in typeAmmount)
            {
                Console.WriteLine($"{present.Key} -> {present.Value}");
            }
        }
    }
}
