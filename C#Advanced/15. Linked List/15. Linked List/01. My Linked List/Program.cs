using System;

namespace CustomDoublyLinkedList
{
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            var ll = new DoublyLinkedList<int>();
            ll.AddFirst(1);
            ll.AddLast(2);
            ll.AddLast(3);
            ll.AddLast(3);
            ll.RemoveLast();
            ll.AddFirst(1);
            ll.RemoveFirst();
            ll.ForEach(n => Console.WriteLine(n));
            var newArray = ll.ToArray();
            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }



        }
    }
}
