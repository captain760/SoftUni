using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            Dictionary<string, int> studentAge = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] nameAge = Console.ReadLine().Split(", ").ToArray();
                studentAge.Add(nameAge[0], int.Parse(nameAge[1]));
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<KeyValuePair<string, int>, string, int, bool> ageCond = (v, x, y) =>
                {
                    switch (x)
                    {
                        case "younger":
                            {
                                if (v.Value < y)
                                    return true;
                                else return false;
                            }
                        case "older":
                            {
                                if (v.Value >= y)
                                    return true;
                                else return false;
                            }
                        
                    }
                    return false;
            };
            Action<KeyValuePair<string, int>, string> print = (v, f) =>
              {
                  switch (f)
                  {
                      case "name":
                          Console.WriteLine(v.Key);
                          break;
                      case "age":
                          Console.WriteLine(v.Value);
                          break;
                      case "name age":
                          Console.WriteLine($"{v.Key} - {v.Value}");
                          break;
                  }
              };
            foreach (var pair in studentAge)
            {
                if (ageCond(pair,condition,age))
                {
                    print(pair, format);
                }
            }
        }
    }
}
