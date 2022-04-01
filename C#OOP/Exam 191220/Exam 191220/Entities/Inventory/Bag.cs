﻿using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {

        private List<Item> items;

        protected Bag(int capacity)
        {
            items = new List<Item>();
            Capacity = capacity;
            this.Capacity = 100;
        }

        public int Capacity { get; set; }

        public int Load
        {
            get
            {
                return items.Sum(x => x.Weight);
            }
        }

        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag), name);
            }
            Item removedOne = items.Where(x => x.GetType().Name == name).FirstOrDefault();
            items.Remove(removedOne);
            return removedOne;
        }
    }
}
