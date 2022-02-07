using System;

namespace _01._List_Implementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList<char> newList = new CustomList<char>();
            newList.Add('a');
            newList.Add('b');
            newList.Add('c');
            newList.Add('d');
            newList.RemoveAt(1);
            newList.Reverse();
            Console.WriteLine("Count = "+newList.Count);
            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }
            Console.WriteLine(newList.ToString());
        }
    }
}
