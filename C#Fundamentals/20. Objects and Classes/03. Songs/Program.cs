using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < numSongs; i++)
            {
                string[] data = Console.ReadLine().Split("_");
                
                string type= data[0];
                string name = data[1];
                string time = data[2];
                Song record = new Song();
                record.TypeList = type;
                record.Name = name;
                record.Time = time;
                songs.Add(record);
            }
            string lastComand = Console.ReadLine();
            if (lastComand == "all")
            {
                foreach (Song item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (Song item in songs)
                {
                    if (item.TypeList == lastComand)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
            //List<Song> filteredSongs = songs.Where(s => s.TypeList == lastComand).ToList();
            //foreach (Song item in songs)
            //{
            //    Console.WriteLine(item.Name);
            //}
        }
    }
}
