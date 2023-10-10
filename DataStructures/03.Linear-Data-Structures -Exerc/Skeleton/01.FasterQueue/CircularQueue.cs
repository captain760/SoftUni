namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;
        public CircularQueue(int capacity =4)
        {
            elements = new T[capacity];
        }
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException();
            }
            var  deletedElement = elements[startIndex];
            this.startIndex= (this.startIndex+1)%this.elements.Length;
            this.Count--;
            
            return deletedElement;
        }

        public void Enqueue(T item)
        {
            if (this.Count>=this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex+1)%this.elements.Length;
            this.Count++;

        }

        private void Grow()
        {
            if (this.startIndex == this.endIndex)
            {
                var newCapacity = this.elements.Length * 2;
                var newElements = new T[newCapacity];
                newElements = CopyElements(newElements);
                this.startIndex = 0;
                this.endIndex = this.Count;
                this.elements = newElements;
            }
        }

        private T[] CopyElements(T[] zeroedArray)
        {
            
            for (int i = 0; i < this.Count; i++)
            {
                zeroedArray[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }
            return zeroedArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            
            for (int i = 0; i < this.Count; i++)
            {
                var index = (this.startIndex + i) % this.elements.Length;
                yield return elements[index];
            }
        }

        public T Peek()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[this.startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyElements(new T[this.Count]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }

}
