using System;
using System.Text;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                
                string input = Console.ReadLine();
                int nameStart = 0;
                int nameLength = 0;
                int ageStart = 0;
                int ageLength = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j].ToString() == "@")
                    {
                        nameStart = j + 1;
                    }
                    if (input[j].ToString() == "|")
                    {
                        nameLength = j - nameStart;
                    }
                    if (input[j].ToString() == "#")
                    {
                        ageStart = j + 1;
                    }
                    if (input[j].ToString() == "*")
                    {
                        ageLength = j - ageStart;
                    }
                }
                string name = input.Substring(nameStart, nameLength);
                string age = input.Substring(ageStart, ageLength);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
