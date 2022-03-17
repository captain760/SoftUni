using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                //if (employee is Manager)
                //{
                //    this.PrintManager((Manager)employee);
                //}
                //else
                //{
                //    this.PrintEmployee(employee);
                //}
                this.PrintEmployee(employee);
            }
        }

        private void PrintEmployee(IEmployee employee)
        {
            employee.Print();
        }

        //private void PrintManager(Manager manager)
        //{
        //    Console.WriteLine(manager.Name);
        //    Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        //}
    }
}
