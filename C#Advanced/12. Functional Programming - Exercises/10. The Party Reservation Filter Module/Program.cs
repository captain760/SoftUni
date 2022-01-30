using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            List<string> filteredList = new List<string>(names);
            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] token = input.Split(";");
                string cmd = token[0];
                string filterType = token[1];
                string filterParameter = token[2];

                switch (cmd)
                {
                    case "Add filter":
                        filteredList.RemoveAll(GetFilter(filterType, filterParameter));
                        break;
                    case "Remove filter":
                        filteredList.AddRange(names.FindAll(GetFilter(filterType, filterParameter)));
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",filteredList));
        }

        private static Predicate<string> GetFilter(string filterType, string filterParameter)
        {
            if (filterType == "Starts with" )
            {
                return x => x.StartsWith(filterParameter);
            }
            if (filterType == "Ends with")
            {
                return x => x.EndsWith(filterParameter);
            }
            if (filterType == "Length")
            {
                int value = int.Parse(filterParameter);
                return x => x.Length == value;
            }
            else
            {
                return x => x.Contains(filterParameter);
            }
        }
    }
}
