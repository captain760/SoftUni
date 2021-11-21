using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = Console.ReadLine();
            string input = Console.ReadLine();
            StringBuilder message = new StringBuilder();
            message.Append(msg);
            while (input != "Reveal")
            {
                string[] cmd = input.Split(":|:");
                if (cmd[0] == "InsertSpace")
                {
                    int index = int.Parse(cmd[1]);
                    message.Insert(index, " ");
                    
                }
                else if (cmd[0] == "Reverse")
                {
                    string substring = cmd[1];
                    if (message.ToString().Contains(substring))
                    {
                        var regex = new Regex(Regex.Escape(substring));             //
                        var newMessage = regex.Replace(message.ToString(), "", 1);  //replace only the first instance of substring in the message
                        message.Clear();
                        message.Append(newMessage);
                        message.Append(Reverse(substring));
                    }
                    else
                    {
                        Console.WriteLine("error");
                        input = Console.ReadLine();
                        continue;
                    }
                    
                }
                else if (cmd[0] == "ChangeAll")
                {
                    string occurance = cmd[1];
                    string replacement = cmd[2];
                    message.Replace(occurance, replacement);
                }
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
        public static string Reverse(string s)  //reverse a string
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
