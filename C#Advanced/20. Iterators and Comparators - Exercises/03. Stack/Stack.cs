using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] stack;
        private int count;
        public MyStack()
        {
            this.stack = new T[4];
            this.count = 0;
        }
        public int Count { get { return count; } }
        public void Push(T element)
        {

            if (count == stack.Length)
            {
                ResizeUp();
            }
            stack[count] = element;
            count++;
            return;
        }
        public void Pop()
        {
            if (count == 0)
            {
                Console.WriteLine("No elements");
                return;
            }
            T removedElement = stack[count - 1];
            count--;
            if (count < stack.Length / 4)
            {
                Shrink();
            }
            return;
        }
        private void Shrink()
        {
            T[] newstack = new T[stack.Length / 2];
            for (int i = 0; i < count; i++)
            {
                newstack[i] = stack[i];
            }
            stack = newstack;
        }

        private void ResizeUp()
        {
            T[] newstack = new T[count * 2];
            for (int i = 0; i < stack.Length; i++)
            {
                newstack[i] = stack[i];
            }
            stack = newstack;
            return;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
