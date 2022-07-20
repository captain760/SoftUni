using EFCoreOverview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace EFCoreOverview
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //Scaffold-DbContext "Server = localhost; Database = SoftUni;User id = sa; Password = yourStrong_Password" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -d
            using (var context = new SoftUniContext())
            {
                var firstEmployee = await context.Employees
                    .Where(e => e.JobTitle == "Design Engineer")
                    .Select(e =>new {e.FirstName, e.LastName})
                    .ToListAsync();
                Console.WriteLine(String.Join(Environment.NewLine,firstEmployee));
            }
            
        }
    }
}