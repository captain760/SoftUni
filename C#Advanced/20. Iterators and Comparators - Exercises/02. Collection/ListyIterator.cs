using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private readonly List<T> elements;
        private int index;
        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            index = 0;
        }
        public bool Move()
        {

            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (index+1<elements.Count)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (elements.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(elements[index]);
            }
            
        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ",elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return elements[index];
            
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
