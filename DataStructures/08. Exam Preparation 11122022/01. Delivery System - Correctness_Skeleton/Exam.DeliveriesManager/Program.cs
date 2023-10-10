using System;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dm = new DeliveriesManager();
            var deliverer1 = new Deliverer("1", "pesho1");
            var deliverer2 = new Deliverer("2", "pesho2");
            var deliverer3 = new Deliverer("3", "pesho3");
            var deliverer4 = new Deliverer("4", "pesho4");
            var package1 = new Package("p1", "Anton", "Varna","123456", 12);
            var package2 = new Package("p2", "Baba", "Varna","123456", 14);
            var package3 = new Package("p3", "Charli", "Varna","123456", 7);
            var package4 = new Package("p4", "Qilo", "Varna","123456", 13);
            var package5 = new Package("p5", "Kilo", "Varna","123456", 13);
            dm.AddDeliverer(deliverer1);
            dm.AddDeliverer(deliverer2);
            dm.AddDeliverer(deliverer3);
            dm.AddDeliverer(deliverer4);
            dm.AddPackage(package1);
            dm.AddPackage(package2);
            dm.AddPackage(package3);
            dm.AddPackage(package4);
            dm.AddPackage(package5);

            dm.AssignPackage(deliverer4, package3);
            dm.AssignPackage(deliverer4, package2);
            dm.AssignPackage(deliverer3, package4);
            dm.AssignPackage(deliverer3, package1);
            dm.AssignPackage(deliverer2, package5);
            
            

            Console.WriteLine(String.Join(", ", dm.GetDeliverers().Select(n=>n.Name)));
            Console.WriteLine(String.Join(", ", dm.GetPackages().Select(n=>n.Id)));
            Console.WriteLine(String.Join(", ", dm.GetUnassignedPackages().Select(n=>n.Id)));
            Console.WriteLine(String.Join(", ", dm.GetPackagesOrderedByWeightThenByReceiver().Select(n=>n.Id)));
            Console.WriteLine(String.Join(", ", dm.GetDeliverersOrderedByCountOfPackagesThenByName().Select(n=>n.Id)));

            
        }
    }
}
