using System;
using System.Collections.Generic;

namespace _03._Take___Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> encripted = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                encripted.Add(input[i]);
            }
            List<int> digits = new List<int>();
            List<char> noDigits = new List<char>();
            for (int i = 0; i < encripted.Count; i++)
            {
                if (encripted[i]>47 && encripted[i]<58)
                {
                    digits.Add(int.Parse(encripted[i].ToString()));
                    
                }
                else
                {
                    noDigits.Add(encripted[i]);
                }
            }
            List<int> take = new List<int>();
            List<int> skip = new List<int>();
            for (int i = 0; i < digits.Count; i++)
            {
                if (i%2==0)
                {
                    take.Add(digits[i]);

                }
                else
                {
                    skip.Add(digits[i]);
                }
            }
            List<char> result = new List<char>();
            int m = 0;
            bool passed = false;
            for (int i = 0; i < noDigits.Count; i++)
            {
                if (!passed)
                {

                    if (take.Count == skip.Count)
                    {
                        for (int j = 0; j < take.Count; j++)
                        {
                            for (int k = 0; k < take[j]; k++)
                            {
                                if (m < noDigits.Count)
                                {
                                    result.Add(noDigits[m]);
                                    m++;
                                }
                            }
                            for (int k = 0; k < skip[j]; k++)
                            {
                                m++;
                            }
                        }
                        passed = true;
                    }
                    else  // take.count>skip.count
                    {
                        for (int j = 0; j < take.Count; j++)
                        {
                            for (int k = 0; k < take[j]; k++)
                            {
                                if (m < noDigits.Count)
                                {
                                    result.Add(noDigits[m]);
                                    m++;
                                }
                            }
                            for (int k = 0; k < skip[j]; k++)
                            {
                                m++;
                            }
                        }

                        for (int k = 0; k < take[take.Count - 1]; k++)
                        {
                            if (m < noDigits.Count)
                            {
                                result.Add(noDigits[m]);
                                m++;
                            }
                        }
                        passed = true;
                    }
                }
                else
                {
                    break;
                }
            }
            
            Console.WriteLine(string.Join("",result));
        }
    }
}
