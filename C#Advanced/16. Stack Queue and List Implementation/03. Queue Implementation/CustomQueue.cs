using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Queue_Implementation
{
    public class CustomQueue<T>
    {
        private const int InitialCapacity = 4;
        private T[] array;
        private int count;
        public CustomQueue()
        {
            this.array = new T[InitialCapacity];
            this.count = 0;
        }
        public int Count =>count; 
        
        public void Enqueue(T element)
        {

            if (count == array.Length)
            {
                ResizeUp();
            }
            array[count] = element;
            count++;
            return;
        }
        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            T removedElement = array[0];
            ShiftToLeft();
            count--;
            if (count < array.Length / 4)
            {
                Shrink();
            }
            return removedElement;
        }

        private void ShiftToLeft()
        {
            var newArray = new T[count-1];
            for (int i = 1; i < count; i++)
            {
                newArray[i - 1] = array[i];
            }
            array = newArray;
        }

        public T Peek()
        {
            T firstElement = array[0];
            return firstElement;
        }

        public void ForEach(Action<T> action)
        {            
            for (int i = 0; i < count; i++)            
            {
                 action(array[i]);   
            }
            return;
        }
        public void Clear()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }
            this.count = 0;
            this.array = new T[InitialCapacity];
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
