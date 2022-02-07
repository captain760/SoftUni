using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Stack_Implementation
{
    public class CustomStack<T>
    {
        private const int InitialCapacity = 4;
        private T[] array;
        private int count;
        public CustomStack()
        {
            this.array = new T[InitialCapacity];
            this.count = 0;
        }
        public int Count { get {return count; } }
        //public T this[int index]
        //{
        //    get
        //    {
        //        if (index >= this.Count)
        //        {
        //            throw new ArgumentOutOfRangeException();
        //        }
        //        return array[index];
        //    }
        //    set
        //    {
        //        if (index >= this.Count)
        //        {
        //            throw new ArgumentOutOfRangeException();
        //        }
        //        array[index] = value;
        //    }
        //}
        public void Push(T element)
        {
            
            if (count==array.Length)
            {
                ResizeUp();
            }
            array[count] = element;
            count++;
            return;
        }
        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            T removedElement = array[count - 1];
            count--;
            if (count<array.Length/4)
            {
                Shrink();
            }
            return removedElement;
        }
        public T Peek()
        {
            T lastElement = array[count - 1];
            return lastElement;
        }

        private void Shrink()
        {
            T[] newArray = new T[array.Length / 2];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        private void ResizeUp()
        {
            T[] newArray = new T[count * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
            return;
        }
    }
}
