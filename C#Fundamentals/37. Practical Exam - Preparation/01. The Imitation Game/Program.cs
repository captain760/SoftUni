using System;
using System.Text;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = Console.ReadLine();
            string input = Console.ReadLine();
            StringBuilder message = new StringBuilder();
            message.Append(msg);
            while (input != "Decode")
            {
                string[] cmd = input.Split("|");
                if (cmd[0] == "Move")
                {
                    int shift = int.Parse(cmd[1]);
                    string endStr = message.ToString().Substring(shift);
                    string startStr = message.ToString().Substring(0,shift);
                    message.Clear();
                    message.Append(endStr);
                    message.Append(startStr);
                }
                else if (cmd[0] == "Insert")
                {
                    int index = int.Parse(cmd[1]);
                    string value = cmd[2];
                    
                    message.Insert(index, value);
                }
                else if (cmd[0] == "ChangeAll")
                {
                    string occurance = cmd[1];
                    string replacement = cmd[2];
                    message.Replace(occurance, replacement);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
