namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get {
                this.ValidateIndex(index);
                return items[index];
            }
            set {
                this.ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();
            this.items[Count++] = item;
            
        }
        
        

        public bool Contains(T item)
        {
            if (this.items.Take(this.Count).Contains(item))
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        public int IndexOf(T item)
        {
            if (!this.items.Contains(item)) { return -1; }
            else
            {
                return Array.IndexOf(items, item);
            }
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            this.Grow();
            
            for (int i = this.Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;                
            }
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.Count--;   
        }

        IEnumerator IEnumerable.GetEnumerator()
            =>this.GetEnumerator();

        private void Grow()
        {
            if (this.Count == this.items.Length)
            {
                T[] itemsCopy = new T[this.items.Length * 2];
                Array.Copy(this.items, itemsCopy, this.items.Length);
                this.items = itemsCopy;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index<0 || index>=this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            
        }
    }
}