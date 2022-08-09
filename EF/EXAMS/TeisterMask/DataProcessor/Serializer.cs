namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            List<ExportProjectDto> projectsDto = context
                .Projects
                .Where(q => q.Tasks.Count > 0)
                .ToList()
                .Select(x => new ExportProjectDto
                {
                    ProjectName = x.Name,
                    TasksCount = x.Tasks.Count,
                    HasEndDate = x.DueDate!=null?"Yes":"No",
                    Tasks = x.Tasks
                    .Select(m => new TaskDto()
                    {
                        Name = m.Name,
                        Label = m.LabelType.ToString()
                    })
                    .OrderBy(x => x.Name)
                    .ToList()
                })
                .OrderByDescending(n => n.TasksCount)
                .ThenBy(i => i.ProjectName)
                .ToList();
            string result = SerializeIt<ExportProjectDto>(projectsDto, "Projects");
            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            
            var EmpTasks = context
              .Employees
              .Where(i => i.EmployeesTasks.Any(f => f.Task.OpenDate >= date))
              .ToArray()
              .Select(x => new
              {
                  Username = x.Username,
                  Tasks = x.EmployeesTasks
                  .Where(c => c.Task.OpenDate >= date)
                  .OrderByDescending(n => n.Task.DueDate)
                  .ThenBy(n => n.Task.Name)
                  .Select(y => new
                  {
                      TaskName = y.Task.Name,
                      OpenDate = y.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                      DueDate = y.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                      LabelType = y.Task.LabelType.ToString(),
                      ExecutionType = y.Task.ExecutionType.ToString()
                  })

              })
              .OrderByDescending(k => k.Tasks.Count())
              .ThenBy(i => i.Username)
              .Take(10)
              .ToArray();
            string json = JsonConvert.SerializeObject(EmpTasks, Formatting.Indented);
            return json;
        }
        private static string SerializeIt<T>(List<T> DtoT, string rootName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), xmlRootAttribute);
            StringBuilder SBOutput = new StringBuilder();
            using StringWriter writer = new StringWriter(SBOutput);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            xmlSerializer.Serialize(writer, DtoT, namespaces);

            return SBOutput.ToString().TrimEnd();

        }
    }
}