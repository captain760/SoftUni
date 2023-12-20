namespace _02.VaniPlanning
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        private Dictionary<string,Invoice> invoices = new Dictionary<string,Invoice>();
        

        public void Create(Invoice invoice)
        {
            if (Contains(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }
            invoices.Add(invoice.SerialNumber, invoice);
        }

        public void ThrowInvoice(string number)
        {
            if (!Contains(number))
            {
                throw new ArgumentException();
            }
            invoices.Remove(number);
        }

        public void ThrowPayed()
        {
            var payed = invoices.Values.Where(i => i.Subtotal == 0);
            foreach (var invoice in payed)
            {
                invoices.Remove(invoice.SerialNumber);
            }
        }

        public int Count()=>invoices.Count;

        public bool Contains(string number)
        {
            return invoices.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            var toPay = invoices.Values.Where(i => i.DueDate.Equals(due));
            if (toPay.Any()) 
            {
                foreach (var inv in toPay) 
                {
                    invoices[inv.SerialNumber].Subtotal = 0;
                    
                }
            }
            else { throw new ArgumentException(); }
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            return invoices.Values.Where(i=>i.IssueDate>= start && i.IssueDate<= end).OrderBy(i=>i.IssueDate).ThenBy(i=>i.DueDate);
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var result = invoices.Values.Where(i=>i.SerialNumber.Contains(serialNumber)).OrderByDescending(i=>i.SerialNumber);
            if (result.Any())
            {
                return result;
            }
            else 
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            var result = invoices.Values.Where(i=>i.DueDate>start && i.DueDate<end);
            if (result.Any())
            {
                foreach (var i in result)
                {
                    invoices.Remove(i.SerialNumber);
                }
                return result;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            return invoices.Values.Where(i => i.Department.Equals(department)).OrderByDescending(i=>i.Subtotal).ThenBy(i=>i.IssueDate);
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            return invoices.Values.Where(i => i.CompanyName.Equals(company)).OrderByDescending(i => i.SerialNumber);
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            var result = invoices.Values.Where(i => i.DueDate.Equals(dueDate));
            
            if (result.Any())
            {
                foreach (var i in result)
                {
                    invoices[i.SerialNumber].DueDate = invoices[i.SerialNumber].DueDate.AddDays(days);
                }               
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
