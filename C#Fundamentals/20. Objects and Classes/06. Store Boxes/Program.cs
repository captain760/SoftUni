using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForABox { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();
            while (input !="end")
            {
                string[] data = input.Split();
                Box currBox = new Box()
                {
                    SerialNumber = data[0],                      
                    ItemQuantity = int.Parse(data[2]),
                    PriceForABox = decimal.Parse(data[3])*int.Parse(data[2])
                };
                //currBox.Item = new Item();
                currBox.Item.Name = data[1]; 
                boxes.Add(currBox);
                input = Console.ReadLine();
            }
            List<Box> sortedBoxes = boxes.OrderByDescending(s => s.PriceForABox).ToList();
            foreach (var item in sortedBoxes)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item.Name} - ${(item.PriceForABox/item.ItemQuantity):f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.PriceForABox:f2}");
            }
        }
    }
}
