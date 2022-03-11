using System;
using System.Collections.Generic;

namespace _06._Money_Transactions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            for (int i = 0; i < elements.Length; i++)
            {
                string[] acc = elements[i]
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);
                int accNum = int.Parse(acc[0]);
                double accBal = double.Parse(acc[1]);
                accounts.Add(accNum, accBal);
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                try
                {
                    string[] cmd = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (cmd[0] == "Deposit")
                    {
                        int accNumToChange = int.Parse(cmd[1]);
                        if (!accounts.ContainsKey(accNumToChange))
                        {
                            throw new ArgumentNullException();
                        }
                        double accBalToAdd = double.Parse(cmd[2]);
                        accounts[accNumToChange] += accBalToAdd;
                        Console.WriteLine($"Account {accNumToChange} has new balance: {accounts[accNumToChange]:f2}");
                    }
                    else if (cmd[0] == "Withdraw")
                    {
                        int accNumToChange = int.Parse(cmd[1]);
                        if (!accounts.ContainsKey(accNumToChange))
                        {
                            throw new ArgumentNullException();
                        }
                        double accBalToSub = double.Parse(cmd[2]);
                        if (accounts[accNumToChange] < accBalToSub)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        accounts[accNumToChange] -= accBalToSub;
                        Console.WriteLine($"Account {accNumToChange} has new balance: {accounts[accNumToChange]:f2}");
                    }
                    else
                    {
                        throw new FormatException();
                    }


                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                input = Console.ReadLine();
            }
        }
    }
}
