namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 4;
        private const double LoadFactor = 0.75;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public HashTable() : this(DefaultCapacity)
        { }

        public HashTable(int capacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();
            int index = GetIndex(key);
            if (this.slots[index] == null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in this.slots[index])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException($"Key already exists! - {key}");
                }
            }

            this.slots[index].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
        }

        private void GrowIfNeeded()
        {
            if ((double)(Count + 1) / Capacity < LoadFactor)
            {
                return;
            }

            var newHashTable = new HashTable<TKey, TValue>(Capacity * 2);
            foreach (var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }
            this.slots = newHashTable.slots;
            Count = newHashTable.Count;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                this.Add(key, value);
                return true;
            }
            catch (ArgumentException ex)
            {
                if (ex.Message.Contains("Key already exists!"))
                {
                    var element = Find(key);
                    element.Value = value;
                    return true;
                }
                throw ex;
            }
        }

        public TValue Get(TKey key)
        {
            var element = Find(key);

            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }
        
        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default;
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int index = GetIndex(key);
            var elements = this.slots[index];
            if (elements != null)
            {
                foreach (var kvp in elements)
                {
                    if (kvp.Key.Equals(key))
                    {
                        return kvp;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key) => Find(key) != null;

        public bool Remove(TKey key)
        {
            int index = GetIndex(key);
            if (this.slots[index] != null)
            {
                var currentNode = this.slots[index].First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        this.slots[index].Remove(currentNode);
                        Count--;
                        return true;
                    }

                    currentNode = currentNode.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys => this.Select(kvp => kvp.Key);

        public IEnumerable<TValue> Values => this.Select(kvp => kvp.Value);

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var set in this.slots)
            {
                if (set != null)
                {
                    foreach (var kvp in set)
                    {
                        yield return kvp;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private int GetIndex(TKey key) => Math.Abs(key.GetHashCode()) % Capacity;
    }
}
