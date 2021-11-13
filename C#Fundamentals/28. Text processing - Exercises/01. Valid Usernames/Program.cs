using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a program that reads user names on a single line(joined by “, “) and prints all valid usernames.
            //A valid username is:
            //•	Has length between 3 and 16 characters
            //•	Contains only letters, numbers, hyphens and underscores
            string[] input = Console.ReadLine().Split(", ");
            foreach (var name in input)
            {
                bool isValid = true;
                if (name.Length <3 || name.Length >16)
                {
                    isValid = false;
                }
                if (isValid)
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (!Char.IsDigit(name[i]) && !Char.IsLetter(name[i]) && name[i] != '_' && name[i] != '-')
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
