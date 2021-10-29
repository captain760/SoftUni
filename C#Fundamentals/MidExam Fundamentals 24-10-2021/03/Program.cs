using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(", ").ToList();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] cmd = input.Split(", ").ToArray();
                if (cmd[0] == "Add")
                {
                    if (cards.Contains(cmd[1]))
                    {
                        Console.WriteLine($"Card is already in the deck");
                    }
                    else
                    {
                        cards.Add(cmd[1]);
                        Console.WriteLine("Card successfully added");
                    }
                }
                else if (cmd[0] == "Remove")
                {
                    if (!cards.Contains(cmd[1]))
                    {
                        Console.WriteLine($"Card not found");
                    }
                    else
                    {
                        cards.Remove(cmd[1]);
                        Console.WriteLine("Card successfully removed");
                    }
                }
                else if (cmd[0] == "Remove At")
                {
                    int index = int.Parse(cmd[1]);
                    if (index>=0 && index<cards.Count)
                    {
                        cards.RemoveAt(index);
                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (cmd[0] == "Insert")
                {
                    int index = int.Parse(cmd[1]);
                    string name = cmd[2];
                    if (index >= 0 && index < cards.Count)
                    {
                        if (cards.Contains(name))
                        {
                            Console.WriteLine("Card is already added");
                        }
                        else
                        {


                            cards.Insert(index, name);
                            Console.WriteLine("Card successfully added");
                        }
                    }
                    else if (index == cards.Count)
                    {
                        cards.Add(name);
                        Console.WriteLine("Card successfully added");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }
            Console.WriteLine(string.Join(", ", cards));
        }
    }
}
