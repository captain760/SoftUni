namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
            public Node(T element)
            {
                Element = element;
            }
        }

        private Node head;
        public int Count { get; private set;}

        public void AddFirst(T item)
        {            
            var node = new Node(item,this.head);
            head = node;            
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next!=null)
                {
                    node = node.Next;
                }
                node.Next = newNode;    
            }
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        public T GetFirst()
        {
            if (this.head==null)
            {
                throw new InvalidOperationException();
            }
            return this.head.Element;
        }

        public T GetLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            var node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Element;
        }
            

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            var oldNode = this.head;
            this.head = oldNode.Next;
            this.Count--;
            return oldNode.Element;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            var node = this.head;
            var oldNode = node;
            while (node.Next!=null)
            {
                oldNode = node;
                node = node.Next;
            }
            
            oldNode.Next = null;
            this.Count--;
            return node.Element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}