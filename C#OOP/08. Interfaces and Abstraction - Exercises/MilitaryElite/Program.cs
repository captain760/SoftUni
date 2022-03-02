using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, Private> privates = new Dictionary<int, Private>();
            string input = Console.ReadLine();
            while (input!="End")
            {
                string[] sld = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = sld[0];
                int id = int.Parse(sld[1]);
                string firstName = sld[2];
                string lastName = sld[3];
                decimal salary = decimal.Parse(sld[4]);
                if (cmd == "Private")
                {
                    Private priv = new Private(id, firstName, lastName, salary);
                    privates.Add(id, priv);
                    Console.WriteLine(priv.ToString());
                }
                else if (cmd == "LieutenantGeneral")
                {
                    Private priv = new Private(id, firstName, lastName, salary);
                    privates.Add(id, priv);
                    LieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < sld.Length; i++)
                    {
                        int privId = int.Parse(sld[i]);
                        lieutenant.Privates.Add(privates[privId]);
                    }
                    Console.WriteLine(lieutenant.ToString());
                }
                else if (cmd == "Engineer")
                {
                    Private priv = new Private(id, firstName, lastName, salary);
                    privates.Add(id, priv);
                    Engineer eng = new Engineer(id, firstName, lastName, salary, sld[5]);
                    if (eng.Corps == "Invalid")
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    for (int i = 6; i < sld.Length; i+=2)
                    {
                        string part = sld[i];
                        int hours = int.Parse(sld[i + 1]);
                        Repair rep = new Repair(part, hours);
                        eng.Repairs.Add(rep);
                    }
                    Console.WriteLine(eng.ToString());
                }
                else if (cmd == "Commando")
                {
                    Private priv = new Private(id, firstName, lastName, salary);
                    privates.Add(id, priv);
                    Commando com = new Commando(id, firstName, lastName, salary, sld[5]);
                    if (com.Corps == "Invalid")
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    for (int i = 6; i < sld.Length; i += 2)
                    {
                        string codeName = sld[i];
                        string state = sld[i + 1];
                        
                        Mission mis = new Mission(codeName, state);
                        if (mis.State == "Invalid")
                        {
                            continue;
                        }
                        com.Missions.Add(mis);
                    }
                    Console.WriteLine(com.ToString());
                }
                else if (cmd == "Spy")
                {
                    int codeNumber = int.Parse(sld[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    Console.WriteLine(spy.ToString());
                }
                input = Console.ReadLine();
            }
            
        }
    }
}
