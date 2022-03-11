using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Play_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int exCount = 0;
            while (exCount<3)
            {
                try
                {
                    string[] cmd = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (cmd[0] == "Replace")
                    {
                        int index = int.Parse(cmd[1]);
                        if (index < 0 || index >= elements.Length)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        int element = int.Parse(cmd[2]);
                        elements[index] = element;
                    }
                    else if (cmd[0] == "Print")
                    {
                        int startIndex = int.Parse(cmd[1]);
                        if (startIndex < 0 || startIndex >= elements.Length)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        int endIndex = int.Parse(cmd[2]);
                        if (endIndex < 0 || endIndex >= elements.Length)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        List<int> list = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {                            
                            list.Add(elements[i]);
                        }
                        Console.WriteLine(string.Join(", ",list));
                    }
                    else if (cmd[0] == "Show")
                    {
                        int index = int.Parse(cmd[1]);
                        if (index < 0 || index >= elements.Length)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        Console.WriteLine(elements[index]);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exCount++;
                }
                catch(FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exCount++;
                }
                
            }
            List<int> finalList = new List<int>(elements);
                     
            Console.WriteLine(string.Join(", ", finalList));
        }
    }
}
