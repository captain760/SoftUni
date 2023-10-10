using NUnit.Framework;
using System;
using TripAdministrations;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ta = new TripAdministrator();

         Company c1 = new Company("a", 2);
         Company c2 = new Company("b", 1);
        Company c3 = new Company("c", 1);
        Company c4 = new Company("d", 2);

        Trip t1 = new Trip("t1", 1, Transportation.NONE, 1);
        Trip t2 = new Trip("t2", 1, Transportation.BUS, 1);
         Trip t3 = new Trip("t3", 1, Transportation.BUS, 1);
         Trip t4 = new Trip("t4", 1, Transportation.BUS, 1);
            ta.AddCompany(c1);
            ta.AddCompany(c2);
            ta.AddCompany(c3);            
            ta.AddCompany(c4);
            ta.AddTrip(c2, t2);
            ta.AddTrip(c2, t1);
            ta.AddTrip(c1, t1);
            ta.AddTrip(c3, t1);
            Console.WriteLine(ta.Exist(t1)); 
        }
    }
}
