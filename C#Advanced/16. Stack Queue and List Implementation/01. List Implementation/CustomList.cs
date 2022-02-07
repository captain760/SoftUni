using System;
using System.Collections.Generic;
using System.Text;

namespace _01._List_Implementation
{
    public class CustomList<T>
    {        
        private T[] array;
        private const int initialSize = 2;
        public CustomList()
        {            
            this.array = new T[initialSize];
        }
        public int Count { get; private set; }
        public T this[int index]
            {
            get
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                array[index] = value;
            }
            }


        public void Add(T element)
        {
            if (array.Length == Count)
            {
                ResizeUp();
            }
            this.array[this.Count] = element;
            this.Count++;
        }
        public T RemoveAt(int index)
        {
            if (index>this.Count || index<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            T removedElement = array[index];
            ShiftLeft(index);
            this.Count--;
            if (this.Count< array.Length/4)
            {
                Shrink();
            }
            return removedElement;
        }
        private void Insert(int index,T element)
        {
            if (index>=this.Count || index<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (array.Length==Count)
            {
                ResizeUp();
            }
            ShiftToRight(index);
            array[index] = element;
            this.Count++;

        }
        public bool Contains(T element)
        {
            foreach (var item in array)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// return the index of the element or -1 if not found
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int Find(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }                
            }
            return -1;
        }
        public void Reverse()
        {
            int counter = this.Count / 2;
            for (int i = 0; i < counter; i++)
            {
                Swap(i, this.Count - 1 - i);
            }
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= this.Count || firstIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (secondIndex >= this.Count || secondIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            T temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
        public string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.AppendLine(array[i].ToString());
            }
            return sb.ToString().TrimEnd();
        }
        private void ResizeUp()
        {            
            T[] newArray = new T[Count * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
            return;
        }
        private void Shrink()
        {
            var shrinkedArray = new T[array.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                shrinkedArray[i] = array[i];
            }
            this.array = shrinkedArray;
            
        }
        private void ShiftLeft(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }                       
            return;
        }
        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}
