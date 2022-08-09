namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {


            List<ExportCoachesDto> coachesDto = context
                .Coaches
                .Where(q => q.Footballers.Count > 0)
                .ToList()
                .Select(x => new ExportCoachesDto
                {
                    FootballersCount = x.Footballers.Count,
                    Name = x.Name,
                    Footballers = x.Footballers
                    .OrderBy(x => x.Name)
                    .Select(m => new ExportFoosDto()
                    {
                        Name = m.Name,
                        PositionType = m.PositionType.ToString()
                    })
                    .ToList()
                })
                .OrderByDescending(n => n.FootballersCount)
                .ThenBy(i => i.Name)
                .ToList();
            string result = SerializeIt<ExportCoachesDto>(coachesDto, "Coaches");
            return result;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsFoos = context
              .Teams              
              .Where(i => i.TeamsFootballers.Any(f=>f.Footballer.ContractStartDate>=date))
              .ToArray()
              .Select(x => new
              {
                  Name = x.Name,
                  Footballers = x.TeamsFootballers
                  .Where(c => c.Footballer.ContractStartDate >= date)
                  .OrderByDescending(n => n.Footballer.ContractEndDate)
                  .ThenBy(n => n.Footballer.Name)
                  .Select(y => new
                  {
                      FootballerName = y.Footballer.Name,
                      ContractStartDate = y.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                      ContractEndDate = y.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                      BestSkillType = y.Footballer.BestSkillType.ToString(),
                      PositionType = y.Footballer.PositionType.ToString()
                  })
                  
              })
              .OrderByDescending(k => k.Footballers.Count())
              .ThenBy(i => i.Name)
              .Take(5)
              .ToArray();
            string json = JsonConvert.SerializeObject(teamsFoos, Formatting.Indented);
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
