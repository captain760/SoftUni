using System;

namespace CollectionHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(addCollection.Add(elements[i])+" ");
            }
            Console.WriteLine();
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(addRemoveCollection.Add(elements[i]) + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(myList.Add(elements[i]) + " ");
            }
            Console.WriteLine();
            int removeNumbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < removeNumbers; i++)
            {
                Console.Write(addRemoveCollection.Remove()+" ");
            }
            Console.WriteLine();
            for (int i = 0; i < removeNumbers; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
