using System;
using System.Collections.Generic;

namespace _04.List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read a number n and n lines of products.Print a numbered list of all the products ordered by name.
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();
            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());
            }
            string min = products[0];
            for (int i = 0; i < products.Count; i++)
            {
                for (int j = i + 1; j < products.Count; j++)
                {
                    if (products[j].CompareTo(products[i])<0)
                    {
                        string temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }
    }
}
