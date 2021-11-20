using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> piecesCompKey = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] initialPiece = Console.ReadLine().Split("|");
                List<string> composerKey = new List<string>();
                string name = initialPiece[0];
                string composer = initialPiece[1];
                string key = initialPiece[2];
                composerKey.Add(composer);
                composerKey.Add(key);
                piecesCompKey.Add(name, composerKey);
            }
            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] token = input.Split("|");
                    string cmd = token[0];
                    string name = token[1];
                if (cmd == "Add")
                {
                    string composer = token[2];
                    string key = token[3];
                    if (piecesCompKey.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} is already in the collection!");
                    }
                    else
                    {
                        List<string> composerKey = new List<string>();
                        composerKey.Add(composer);
                        composerKey.Add(key);
                        piecesCompKey.Add(name, composerKey);
                        Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                    }
                }
                else if (cmd=="Remove")
                {
                    if (piecesCompKey.ContainsKey(name))
                    {
                        piecesCompKey.Remove(name);
                        Console.WriteLine($"Successfully removed {name}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                }
                else if (cmd == "ChangeKey")
                {
                    string newKey = token[2];
                    if (piecesCompKey.ContainsKey(name))
                    {
                        List<string> composerKey = new List<string>();
                        composerKey.Add(piecesCompKey[name][0]);
                        composerKey.Add(newKey);
                        piecesCompKey[name] = composerKey;
                        Console.WriteLine($"Changed the key of {name} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }

                }

                input = Console.ReadLine();
            }
            piecesCompKey = piecesCompKey.OrderBy(x => x.Key).ThenBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in piecesCompKey)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
