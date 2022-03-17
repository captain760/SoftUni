using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee me = new Employee("Bobo");
            List<string> docs = new List<string> { "cv", "motivation letter", "reccomendations" };
            Manager myBoss = new Manager("Boss", docs);
            IList<IEmployee> all = new List<IEmployee> { me, myBoss };
            DetailsPrinter allColeagues = new DetailsPrinter(all);
            allColeagues.PrintDetails();
        }
    }
}
