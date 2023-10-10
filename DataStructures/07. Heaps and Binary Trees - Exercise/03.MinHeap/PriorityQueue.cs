using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public void Enqueue(T element)
        {
           this.elements.Add(element);
            this.HeapifyUp(Count - 1);
        }

        public T Dequeue()
        {
            return ExtractMin();
        }

        public void DecreaseKey(T key)
        {
            var index = this.elements.IndexOf(key);
            this.HeapifyUp(index);
        }
    }
}
