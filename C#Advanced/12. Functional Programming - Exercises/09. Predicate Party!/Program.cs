using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();
            while (input!="Party!")
            {
                string[] token = input.Split();
                string cmd = token[0];
                string condition = token[1];
                string subCond = token[2];
                Func<List<string>, string, string, List<string>> doubl = (n, x, y) =>
                {
                    if (x == "StartsWith")
                    {
                        int initCount = n.Count;
                        for (int i = 0; i < initCount; i++)
                        {
                            if (n[i].StartsWith(y))
                            {
                                n.Add(n[i]);
                            }
                        }
                    }
                    if (x == "EndsWith")
                    {
                        int initCount = n.Count;
                        for (int i = 0; i < initCount; i++)
                        {
                            if (n[i].EndsWith(y))
                            {
                                n.Add(n[i]);
                            }
                        }
                    }
                    if (x == "Length")
                    {
                        int nameLength = int.Parse(y);
                        int initCount = n.Count;
                        for (int i = 0; i < initCount; i++)
                        {
                            if (n[i].Length== nameLength)
                            {
                                n.Add(n[i]);
                            }
                        }
                    }
                    return n;
                };
                Func<List<string>, string, string, List<string>> rem = (n, x, y) =>
                  {
                      if (x == "StartsWith")
                      {
                          n.RemoveAll(k => k.StartsWith(y));
                          
                      }
                      if (x=="EndsWith")
                      {
                          n.RemoveAll(k => k.EndsWith(y));
                          
                      }
                      if (x=="Length")
                      {
                          int nameLength = int.Parse(y);
                          n.RemoveAll(k => k.Length==nameLength);
                         
                      }
                      return n;
                  };
                
                switch (cmd)
                {
                    case "Remove":
                        names = rem(names, condition, subCond);
                        break;
                    case "Double":
                        names = doubl(names, condition, subCond);
                        break;
                }
                input = Console.ReadLine();
            }
            //names.Sort();
            //if (names.Count ==0 || (names.Count==1 && names[0] == string.Empty))
            if (!names.Any())
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ",names)} are going to the party!");
            }
        }
    }
}
