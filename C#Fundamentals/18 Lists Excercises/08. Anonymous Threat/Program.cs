using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            List<string> symbols = input.Split().ToList();


            string com = Console.ReadLine();
            while (com != "3:1")
            {
                string[] incoming = com.Split();
                if (incoming[0] == "merge")
                {
                    int startIndex = int.Parse(incoming[1]);
                    int endIndex = int.Parse(incoming[2]);
                    if (startIndex<0)
                    {
                        startIndex = 0;
                    }
                    if (startIndex<symbols.Count)
                    {
                        if (endIndex>=symbols.Count)
                        {
                            endIndex = symbols.Count-1;
                        }
                        if (endIndex>=startIndex)
                        {
                            string rezult = "";
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                rezult += symbols[i];
                                
                            }
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                
                                symbols.RemoveAt(startIndex);
                            }
                            symbols.Insert(startIndex, rezult);
                           
                        }
                    }
                }
                else if (incoming[0] == "divide")
                {
                    int index = int.Parse(incoming[1]);
                    int parts = int.Parse(incoming[2]);
                    string dev = symbols[index];
                    int strLength = dev.Length;
                    int symPerPart = strLength / parts;
                    string res = "";
                    int k = 0;
                    if (symPerPart >= 1 && parts>1)
                    {


                        for (int i = 0; i < parts - 1; i++)
                        {

                            for (int j = 0; j < symPerPart; j++)
                            {
                                res += dev[k].ToString();
                                k++;
                            }
                            res += " ";
                        }
                        for (int i = k; i < strLength; i++)
                        {
                            res += dev[i].ToString();                                                        
                        }
                        List<string> toadd = res.Split().ToList();
                        symbols.RemoveAt(index);
                        symbols.InsertRange(index,toadd);
                        
                    }
                }

                com = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", symbols));
        }
    }
}
