using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private T element;
        private List<T> elementsList = new List<T>();
        public int Count { get {return elementsList.Count; } }
        public void Add(T element)
        {
            elementsList.Add(element);
        }
        public T Remove()
        {
            T removedElement = elementsList.Last();
            elementsList.RemoveAt(elementsList.Count - 1);
            return removedElement;
        }
    }
}
