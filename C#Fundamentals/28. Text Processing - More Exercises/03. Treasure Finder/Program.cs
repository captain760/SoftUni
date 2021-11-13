using System;
using System.Linq;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "find")
            {
                StringBuilder msg = new StringBuilder(input.Length);
                for (int i = 0, j = 0; i < input.Length; i++)
                {
                    
                    msg.Append((char)(input[i] - key[j]));
                    if (j == key.Length-1)
                    {
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }
                    //_ = j == key.Length ? j = 0 : j++;
                    
                }
                string message = msg.ToString();
                int nameStart = message.IndexOf('&');
                int nameLength = message.LastIndexOf('&') - nameStart - 1;
                int posStart = message.IndexOf('<');
                int posLength = message.IndexOf('>') - posStart - 1;
                string name = message.Substring(nameStart+1, nameLength);
                string position = message.Substring(posStart+1, posLength);
                Console.WriteLine($"Found {name} at {position}");

                input = Console.ReadLine();
            }
            
        }
    }
}
