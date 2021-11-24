using System;
using System.Text;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            string input = Console.ReadLine();
            while (input!="Generate")
            {
                string[] token = input.Split(">>>");
                if (token[0] == "Contains")
                {
                    string substring = token[1];
                    if (rawKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (token[0] == "Flip")
                {
                    string upperLower = token[1];
                    int startIndex = int.Parse(token[2]);
                    int endIndex = int.Parse(token[3]);
                    string substring = rawKey.Substring(startIndex, endIndex-startIndex);
                    string formatedSubstring = "";
                    if (upperLower == "Upper")
                    {
                        formatedSubstring = substring.ToUpper();

                    }
                    else if (upperLower == "Lower")
                    {
                        formatedSubstring = substring.ToLower();
                    }
                    StringBuilder result = new StringBuilder();
                    result.Append(rawKey.Substring(0, startIndex));
                    result.Append(formatedSubstring);
                    result.Append(rawKey.Substring(endIndex));
                    rawKey = result.ToString();
                    Console.WriteLine(rawKey);
                }
                else if (token[0] == "Slice")
                {
                    int startIndex = int.Parse(token[1]);
                    int endIndex = int.Parse(token[2]);
                    string slicedRawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                    rawKey = slicedRawKey;
                    Console.WriteLine(rawKey);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
