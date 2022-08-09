namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            // with Anonymous Objects( not DTOs)
            var prisoners = context
                .Prisoners
                .Where(i => ids.Contains(i.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                    .Select(y => new
                    {
                        OfficerName = y.Officer.FullName,
                        Department = y.Officer.Department.Name
                    })
                    .OrderBy(n => n.OfficerName)
                    .ToList(),
                    TotalOfficerSalary =decimal.Parse(x.PrisonerOfficers
                    .Sum(s=>s.Officer.Salary).ToString("F2"))

                })
                .OrderBy(n=>n.Name)
                .ThenBy(i=>i.Id)
                .ToList();
            string json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return json;

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] stringElements = prisonersNames
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

            List<ExportPrisonerDto> prisonersDto = context
                .Prisoners
                .Where(q=>stringElements.Contains(q.FullName))
                .Select(x => new ExportPrisonerDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Mails = x.Mails.Select(m => new ExportPrisonerMailsDto()
                    {
                        //Description = new String(Array.Reverse(m.Description.ToCharArray()))
                        Description = String.Join("",m.Description.Reverse())
                    })
                    .ToArray()
                })
                .OrderBy(n=>n.FullName)
                .ThenBy(i=>i.Id)
                .ToList();
            string result = SerializeIt<ExportPrisonerDto>(prisonersDto, "Prisoners");
            return result;
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