using _01.Microsystem;
using _02.VaniPlanning;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var microsystems = new Microsystems();
            //var computer1 = new Computer(1, Brand.DELL, 2300.0, 15.6, "grey");
            //var computer2 = new Computer(3, Brand.DELL, 2200.0, 15.6, "grey");
            //var computer3 = new Computer(4, Brand.DELL, 2800.0, 15.6, "grey");
            //var computer4 = new Computer(5, Brand.ACER, 2300.0, 15.6, "grey");


            //microsystems.CreateComputer(computer1);
            //microsystems.CreateComputer(computer2);
            //microsystems.CreateComputer(computer3);
            //microsystems.CreateComputer(computer4);

            //Console.WriteLine(String.Join(", ",microsystems.GetAllFromBrand(Brand.DELL).ToList()));

            var agency = new Agency();
            var invoice = new Invoice("123", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 28), new DateTime(2000, 10, 28));
            var invoice2 = new Invoice("435", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 29), new DateTime(2000, 10, 28));
            var invoice3 = new Invoice("444", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 30), new DateTime(2001, 09, 28));
            var invoice4 = new Invoice("test3", "VMWare", 1200, Department.Sells, new DateTime(2000, 10, 28), new DateTime(2001, 11, 20));
            var invoice5 = new Invoice("test", "Musala", 1200, Department.Sells, new DateTime(2000, 05, 28), new DateTime(2001, 11, 20));


            //Act

            agency.Create(invoice);
            agency.Create(invoice2);
            agency.Create(invoice3);
            agency.Create(invoice4);
            agency.Create(invoice5);
            var expectedDate = new DateTime(2001, 11, 25);
            agency.ExtendDeadline(new DateTime(2001, 11, 20), 5);

            Console.WriteLine(String.Join(", ", agency.GetAllFromDepartment(Department.Sells)));
        }
    }
}