using System;
using System.Text;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = Console.ReadLine();
            string input = Console.ReadLine();
            StringBuilder password = new StringBuilder();
            password.Append(msg);
            while (input != "Done")
            {
                string[] token = input.Split();
                string cmd = token[0];
                if (cmd == "TakeOdd")
                {
                    password.Clear();
                    for (int i = 1; i < msg.Length; i += 2)
                    {
                        password.Append(msg[i]);
                    }
                    msg = password.ToString();
                    Console.WriteLine(password);
                }
                else if (cmd == "Cut")
                {
                    int index = int.Parse(token[1]);
                    int length = int.Parse(token[2]);

                    password.Remove(index, length);
                    msg = password.ToString();
                    Console.WriteLine(password);
                }
                else if (cmd == "Substitute")
                {
                    string substring = token[1];
                    string substitute = token[2];
                    if (msg.IndexOf(substring) < 0)
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    else
                    {
                        password.Replace(substring, substitute);
                        msg = password.ToString();
                        Console.WriteLine(password);
                    }
                }



                input = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
