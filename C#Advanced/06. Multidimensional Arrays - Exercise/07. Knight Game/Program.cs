using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _07._Knight_Game
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //reading
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = row[j];
                }
            }
            //logic
            //creating database structure
            Dictionary<Point, int> hits = new Dictionary<Point, int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == 'K')
                    {
                        Point coor = new Point(i, j);
                        hits.Add(coor, 0);
                    }
                }
            }
            //checking numbers of attacks for each Knight
            int removedKnights = 0;
            hits = Atacks(hits);
            while (hits.Count != 0 && hits.Values.Any(x=>x!=0))
            {
                int maxHits = 0;
                Point maxHitsPoint = new Point(0, 0);
                for (int k = 0; k < hits.Count; k++)
                {
                    var item = hits.ElementAt(k);
                    if (item.Value > maxHits)
                    {
                        
                        maxHitsPoint = item.Key;
                        maxHits = item.Value;
                    }
                }
                hits.Remove(maxHitsPoint);
                removedKnights++;
                hits.Keys.ToList().ForEach(x => hits[x] = 0);//nulling the dictionary
                    hits = Atacks(hits);
            }
            Console.WriteLine(removedKnights);
        }
        static Dictionary<Point, int> Atacks(Dictionary<Point, int> hits)
        {
            for (int k = 0; k < hits.Count; k++)
            {
                var item = hits.ElementAt(k);

                Point currKnight = item.Key;
                int i = currKnight.X;
                int j = currKnight.Y;
                Point otherKnight1 = new Point(i - 2, j - 1);
                if (hits.ContainsKey(otherKnight1))
                {
                    hits[currKnight]++;
                }
                Point otherKnight2 = new Point(i - 2, j + 1);
                if (hits.ContainsKey(otherKnight2))
                {
                    hits[currKnight]++;
                }
                Point otherKnight3 = new Point(i - 1, j - 2);
                if (hits.ContainsKey(otherKnight3))
                {
                    hits[currKnight]++;
                }
                Point otherKnight4 = new Point(i - 1, j + 2);
                if (hits.ContainsKey(otherKnight4))
                {
                    hits[currKnight]++;
                }
                Point otherKnight5 = new Point(i + 1, j - 2);
                if (hits.ContainsKey(otherKnight5))
                {
                    hits[currKnight]++;
                }
                Point otherKnight6 = new Point(i + 1, j + 2);
                if (hits.ContainsKey(otherKnight6))
                {
                    hits[currKnight]++;
                }
                Point otherKnight7 = new Point(i + 2, j - 1);
                if (hits.ContainsKey(otherKnight7))
                {
                    hits[currKnight]++;
                }
                Point otherKnight8 = new Point(i + 2, j + 1);
                if (hits.ContainsKey(otherKnight8))
                {
                    hits[currKnight]++;
                }
            }
            return hits;
        }
    }
}
