using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine:IEngine
    {
        private ICommandInterpreter commandInterpretator;

        public Engine(ICommandInterpreter commandInterpretator)
        {
            this.commandInterpretator = commandInterpretator;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    string result = this.commandInterpretator.Read(input);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
