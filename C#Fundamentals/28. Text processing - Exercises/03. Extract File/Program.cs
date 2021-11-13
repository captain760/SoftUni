using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads the path to a file and subtracts the file name and its extension.
            string input = Console.ReadLine();
            int index = input.LastIndexOf("\\");
            input = input.Substring(index+1);
            string[] file = input.Split(".");
            Console.WriteLine($"File name: {file[0]}");
            Console.WriteLine($"File extension: {file[1]}");
        }
    }
}
