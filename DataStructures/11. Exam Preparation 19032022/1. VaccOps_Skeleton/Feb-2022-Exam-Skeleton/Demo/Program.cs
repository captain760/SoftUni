using System;
using System.Linq;
using VaccOps;
using VaccOps.Models;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var vo = new VaccDb();
            var d1 = new Doctor("d1", 2);
            var d2 = new Doctor("d2", 2);
            var d3 = new Doctor("d3", 2);
            var d4 = new Doctor("d4", 2);

            var p1 = new Patient("p1", 178, 24, "Varna");
            var p2 = new Patient("p2", 179, 21, "Varna");
            var p3 = new Patient("p3", 178, 24, "Sofia");
            var p4 = new Patient("p4", 180, 28, "Varna");
            var p5 = new Patient("p5", 178, 21, "Burgas");

            vo.AddDoctor(d1);
            vo.AddDoctor(d2);
            vo.AddDoctor(d3);
            vo.AddDoctor(d4);

            vo.AddPatient(d1,p1);
            vo.AddPatient(d2,p2);
            vo.AddPatient(d2,p3);
            vo.ChangeDoctor(d2, d3, p3);
           

            Console.WriteLine(string.Join(", ", vo.GetDoctorsSortedByPatientsCountDescAndNameAsc().Select(x=>x.Name)));
            
        }
    }
}
