using System;
using System.Collections.Generic;

namespace Exam.Discord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            Discord discord = new Discord();

            discord.SendMessage(new Message("1234", "hello", 76, "blabla"));

            discord.ReactToMessage("1234", "like1");
            discord.ReactToMessage("1234", "like2");
            discord.ReactToMessage("1234", "like3");

            var reactions = new List<string>()
            {
                "like1",
                "like2",
                "like3"
            };

            var result = discord.GetMessagesByReactions(reactions);

            Console.WriteLine(string.Join(' ', result));

            var message = discord.GetMessage("1234");

            Console.WriteLine(discord.Contains(message));
        }
    }
}
