namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            List<ImportProjectDto> dtoProjects = DeserializeIt<ImportProjectDto>(xmlString, "Projects");
            StringBuilder sb = new StringBuilder();
            List<Project> validProjects = new List<Project>();
            foreach (ImportProjectDto pDto in dtoProjects)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime projectOpenDate;
                bool isProjectOpenDateValid = DateTime.TryParseExact(pDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);
                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime? projectDueDate = null;
                if (!String.IsNullOrEmpty(pDto.DueDate))
                {
                    DateTime projectDueDateValue;
                    bool isProjectDueDateValid = DateTime.TryParseExact(pDto.DueDate, "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDateValue);
                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    projectDueDate = projectDueDateValue;
                }
                
                Project p = new Project()
                {
                    Name = pDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };
                foreach (var tDto in pDto.Tasks)
                {
                    if (!IsValid(tDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(tDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);
                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(tDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);
                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    if (tDto.ExecutionType<0 || tDto.ExecutionType>3)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    if (tDto.LabelType < 0 || tDto.LabelType > 4)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate || taskDueDate>projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = tDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)tDto.ExecutionType,
                        LabelType = (LabelType)tDto.LabelType
                    };
                    p.Tasks.Add(t);
                }


                validProjects.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedProject,p.Name,p.Tasks.Count));
            }
            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Employee> validEmps = new List<Employee>();

            var emps = JsonConvert.DeserializeObject<ImportEmplDto[]>(jsonString);

            foreach (var emp in emps)
            {
                if (!IsValid(emp))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee validEmp = new Employee()
                {
                    Username = emp.Username,
                    Email = emp.Email,
                    Phone = emp.Phone
                };

                foreach (var t in emp.Tasks.Distinct())
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!context.Tasks.Any(x => x.Id == t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validEmp.EmployeesTasks.Add(new EmployeeTask()
                    {
                        TaskId = t,
                        EmployeeId = validEmp.Id
                    });

                }

                validEmps.Add(validEmp);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee,validEmp.Username,validEmp.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmps);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
        private static List<T> DeserializeIt<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), xmlRootAttribute);

            using StringReader reader = new StringReader(inputXml);

            List<T> DtoT = (List<T>)xmlSerializer.Deserialize(reader);

            return DtoT;
        }
    }
}