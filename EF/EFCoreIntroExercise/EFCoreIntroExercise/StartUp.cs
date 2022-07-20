using System;

namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public static class StartUp
    {
        static void Main(string[] args)
        {
            //var cultureInfo = new CultureInfo("fr-FR");
            //cultureInfo.DateTimeFormat.DateSeparator = "/";
            SoftUniContext context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(context));//Problem03
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));//Problem04
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));//Problem05
            //Console.WriteLine(AddNewAddressToEmployee(context));//Problem06
            //Console.WriteLine(GetEmployeesInPeriod(context));//Problem07
            //Console.WriteLine(GetAddressesByTown(context));//Problem08
            //Console.WriteLine(GetEmployee147(context));//Problem09
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));//Problem10
            //Console.WriteLine(GetLatestProjects(context));//Problem11
            //Console.WriteLine(IncreaseSalaries(context));//Problem12
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));//Problem13
            //Console.WriteLine(DeleteProjectById(context));//Problem14
            Console.WriteLine(RemoveTown(context));//Problem15
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var allEmployees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();
            foreach (var employee in allEmployees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return output.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var allEmployees = context
                            .Employees
                            .Where(e=>e.Salary>50000)
                            .Select(e => new
                            {
                                e.FirstName,                                
                                e.Salary
                            })
                            .OrderBy(e => e.FirstName)
                            .ToList();
            StringBuilder output = new StringBuilder();
            foreach (var employee in allEmployees)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return output.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var allEmployees = context
                            .Employees
                            .Where(e => e.Department.Name == "Research and Development")
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.Department.Name,
                                e.Salary
                            })
                            .OrderBy(e => e.Salary)
                            .ThenByDescending(e=>e.FirstName)
                            .ToList();
            StringBuilder output = new StringBuilder();
            foreach (var employee in allEmployees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }
            return output.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAddress);
            Employee nakov = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = newAddress;
            context.SaveChanges();
            var top10addresses = context
                .Employees
                .OrderByDescending(a => a.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10)                
                .ToList();
            foreach (var adr in top10addresses)
            {
                output.AppendLine($"{adr}");
            }
            return output.ToString().TrimEnd();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var output = new StringBuilder();
            var perEmpl = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    allProjects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToArray()
                })
                .ToArray();
            foreach (var ep in perEmpl)
            {
                output.AppendLine($"{ep.FirstName} {ep.LastName} - Manager: {ep.ManagerFirstName} {ep.ManagerLastName}");
               foreach (var p in ep.allProjects)
                {
                    output.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }
            return output.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var output = new StringBuilder();
            var adrs = context
                .Addresses                
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmpCount = a.Employees.Count()
                })
                
                .OrderByDescending(x=>x.EmpCount)
                .ThenBy(a=>a.TownName)
                .ThenBy(a=>a.AddressText)
                .Take(10)
                .ToArray();
            foreach (var adr in adrs)
            {
                output.AppendLine($"{adr.AddressText}, {adr.TownName} - {adr.EmpCount} employees");
            }

            return output.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var output = new StringBuilder();
            var emp147 = context
                .Employees
                .Include(ep=>ep.EmployeesProjects)
                .ThenInclude(p=>p.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);
                
                string[] projectNames = emp147.EmployeesProjects
                .Select(e =>e.Project.Name)
                .OrderBy(n => n)
                .ToArray();

            output.AppendLine($"{emp147.FirstName} {emp147.LastName} - {emp147.JobTitle}");
            foreach (var p in projectNames)
            {
                output.AppendLine(p);
            }

            return output.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var dep5 = context
                .Departments
                .Include(x=>x.Manager)
                .Where(e => e.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(dn => dn.Name)
                .ToArray();
            foreach (var d in dep5)
            {
                sb.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");
                var emps = context
                    .Employees
                    .Where(x => x.Department.Name == d.Name)
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToArray();
                foreach (var emp in emps)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var latest10 = context
                .Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x=>x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    StDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture)
                })
                .ToArray();
            foreach(var d in latest10)
            {
                sb.AppendLine($"{d.Name}");
                sb.AppendLine($"{d.Description}");
                sb.AppendLine($"{d.StDate}");
            }
            
            return sb.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            
            var emps = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .OrderBy(e=>e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();
            foreach (var e in emps)
            {
                e.Salary *= 1.12m;
            }
            context.SaveChanges();
            
            var sb = new StringBuilder();
            foreach (var e in emps)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var emps = context
                .Employees
                .Where(e => e.FirstName.StartsWith("sa") || e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();
            
            var sb = new StringBuilder();
            foreach (var e in emps)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projToRemove = context
                .Projects
                .Find(2);
            var empToRef = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projToRemove.ProjectId)
                .ToArray();
            context.EmployeesProjects.RemoveRange(empToRef);
            context.Projects.Remove(projToRemove);
            var projectsLeft = context
                .Projects
                .Select(p=>p.Name)
                .Take(10)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var item in projectsLeft)
            {
                sb.AppendLine(item);
            }
            return sb.ToString().TrimEnd();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            Town townToRemove = context
                .Towns
                .FirstOrDefault(t => t.Name == "Seattle");
            var adrIdToRemove = context
                .Addresses
                .Where(t => t.TownId == townToRemove.TownId)
                .Select(a=>a.AddressId)
                .ToArray();
            var emplToChangeAddressId = context
                .Employees
                .Where(e=> e.AddressId.HasValue && adrIdToRemove.Contains(e.AddressId.Value))
                .ToArray();
            int cnt = 0;
            foreach (var empl in emplToChangeAddressId)
            {
                empl.AddressId = null;
                cnt++;
            }  
            context.Addresses.RemoveRange(context.Addresses.Where(a=>a.Town.Name == "Seattle"));
            context.Towns.Remove(townToRemove);
            context.SaveChanges();
            var sb = new StringBuilder();
            sb.AppendLine($"{adrIdToRemove.Length} addresses in Seattle were deleted");
            return sb.ToString().TrimEnd();
        }
    }
    
}
