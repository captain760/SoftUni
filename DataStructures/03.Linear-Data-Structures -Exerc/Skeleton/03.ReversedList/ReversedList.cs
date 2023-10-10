namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return items[this.Count -1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                items[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index<0 || index>=this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count==this.items.Length)
            {
                this.Grow();
            }
            items[this.Count++] = item;
        }

        private void Grow()
        {
            var newArray = new T[this.Count*2];
            Array.Copy(items, newArray, this.Count);
            this.items = newArray;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item)!=-1;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count-1; i >=0; i--)
            {
                if (items[i].Equals(item))
                {
                    return this.Count-1-i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            if (this.Count == this.items.Length)
            {
                this.Grow();
            }
            index = this.Count - index;
            for (int i = this.Count; i > index; i--)
            {
                items[i] = items[i-1];
            }
            items[index] = item; 
            this.Count++;
        }

        public bool Remove(T item)
        {
            if (!this.Contains(item)) { return false; }
            var index = this.IndexOf(item);
            this.RemoveAt(index);
            return true;
            
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
              
            for (int i = this.Count-1-index; i < this.Count; i++)
            {
                items[i] = items[i + 1];
            }
            this.items[this.Count-1] = default(T);  
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count-1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}