using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;
        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        public void HeapifyUp(int index)
        {
            while (true)
            {
                var parentIndex = (index - 1) / 2;
                if (index > 0 && elements[parentIndex].CompareTo(elements[index]) > 0)
                {
                    var temp = elements[parentIndex];
                    elements[parentIndex] = elements[index];
                    elements[index] = temp;
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
            
        }

        
        

        public T ExtractMin()
        {            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            T result = this.elements[0];
            elements[0] = this.elements[Size-1];
            elements[Size-1] = result;
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return result;
        }

        private void HeapifyDown(int index)
        {
            var smallerChildIndex = this.GetSmallerChildIndex(index);

            while (IsIndexValid(smallerChildIndex) && elements[index].CompareTo(elements[smallerChildIndex])>0)
            {
                var temp = elements[smallerChildIndex];
                elements[smallerChildIndex] = elements[index];
                elements[index] = temp;

                index = smallerChildIndex;
                smallerChildIndex = this.GetSmallerChildIndex(index);

            }
        }

        private int GetSmallerChildIndex(int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;
            if (Size<leftChildIndex+1)
            {                
                return -1;
            }
            else if (Size<rightChildIndex+1 || elements[leftChildIndex].CompareTo(elements[rightChildIndex])<=0)
            {
                return leftChildIndex;
            }
            else
            {
                return rightChildIndex;
            }
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < Size;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            return this.elements[0];
        }
    }
}
