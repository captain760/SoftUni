using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }
            public T Value { get; set; }

        }
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node<T>(element);
            }
            else
            {
                Node<T> newHead = new Node<T>(element);
                newHead.Next = this.head;
                this.head.Prev = newHead;
                this.head = newHead;
            }
            this.Count++;
        }
        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node<T>(element);
            }
            else
            {
                Node<T> newTail = new Node<T>(element);
                newTail.Prev = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
            else if (this.Count ==1)
            {
                T firstElement = this.head.Value;
                this.head = this.tail = null;
                this.head.Next = this.tail.Next = this.head.Prev = this.tail.Prev = null;
                this.Count--;
                return firstElement;
            }
            else
            {
                T firstElement = this.head.Value;
                this.head = this.head.Next;
                this.head.Prev = null;
                this.Count--;
                return firstElement;
            }
            
        }
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else if (this.Count == 1)
            {
                T lastElement = this.tail.Value;
                this.head = this.tail = null;
                this.head.Next = this.tail.Next = this.head.Prev = this.tail.Prev = null;
                this.Count--;
                return lastElement;
            }
            else
            {
                T lastElement = this.tail.Value;
                this.tail = this.tail.Prev;
                this.tail.Next = null;
                this.Count--;
                return lastElement;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public T[] ToArray()
        {
            int arrayLength = this.Count;
            T[] array = new T[arrayLength];
            Node<T> currentNode = this.head;
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.Next;
            }
            return array;
        }
    }
}
