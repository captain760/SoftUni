using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] tickets = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] trimmedInput = new string[tickets.Length];
            for (int i = 0; i < tickets.Length; i++)
            {
                string CurrTrimming = tickets[i].Trim();
                trimmedInput[i] = CurrTrimming;
            }
            string regexValidation = @"[^,]{20}";
            string regexSpecialValidation = @"[$]{6,10}|[#]{6,10}|[@]{6,10}|[\^]{6,10}";

            foreach (var ticket in trimmedInput)
            {
                Match validTicket = Regex.Match(ticket, regexValidation);
                if (!validTicket.Success)
                {
                    Console.WriteLine($"invalid ticket");
                    continue;
                }
                else
                {
                    StringBuilder left = new StringBuilder();
                    StringBuilder right = new StringBuilder();

                    for (int i = 0; i < ticket.Length / 2; i++)
                    {
                        left.Append(ticket[i]);
                    }
                    for (int i = 10; i < ticket.Length; i++)
                    {
                        right.Append(ticket[i]);
                    }
                    Match winnerLeft = Regex.Match(left.ToString(), regexSpecialValidation);
                    Match winnerRight = Regex.Match(right.ToString(), regexSpecialValidation);

                    if ((winnerLeft.ToString().Contains(winnerRight.ToString()) || winnerRight.ToString().Contains(winnerLeft.ToString())) && (winnerRight.ToString() != "" && winnerLeft.ToString() != ""))
                    {
                        if (winnerRight.ToString().Length == 10 && winnerLeft.ToString().Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {winnerRight.Length}{winnerRight.ToString()[0]} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(winnerRight.Length, winnerLeft.Length)}{winnerRight.ToString()[0]}");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }

            }

        }
    }
}
