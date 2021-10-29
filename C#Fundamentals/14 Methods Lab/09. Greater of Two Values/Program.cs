using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given an input of two values of the same type. The values can be of type int, char, or String.Create a
            //method called getMax() that returns the parameter with the biggest value.
            string type = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            Console.WriteLine(getMax(type,first,second));
        }
        static string getMax(string type, string first, string second)
        {
            switch (type)
            {
                case "int":
                    {
                        if (int.Parse(first) > int.Parse(second))
                        {
                            return first;
                        }
                        else if (int.Parse(first) < int.Parse(second))
                        {
                            return second;
                        }
                        break;
                    }
                case "char":
                    {
                        if (first[0] > second[0])
                        {
                            return first.ToString();
                        }
                        else if (first[0] < second[0])
                        {
                            return second.ToString();
                        }
                        break;
                    }
                case "string":
                    {
                       
                            if (first.CompareTo(second)>0)
                            {
                                return first;
                            }
                            else if (first.CompareTo(second) < 0)
                            {
                                return second;
                            }
                        
                        break;
                    }
                default:
                    break;
            }
            return "";
        }
        static int StrToInt(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                result += (int)str[i];
            }
            return result;
        }
    }
}
