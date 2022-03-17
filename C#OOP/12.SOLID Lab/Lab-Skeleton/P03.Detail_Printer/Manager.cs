using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents) 
        {
            this.Name = name;
            this.Documents = new List<string>(documents);
        }
        public string Name { get; set; }

        public IReadOnlyCollection<string> Documents { get; set; }

        public void Print()
        {
            Console.WriteLine(Name);
            Console.WriteLine(string.Join(Environment.NewLine, Documents));
        }
    }
}
