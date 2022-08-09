namespace Footballers.DataProcessor
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
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            List<ImportCoachDto> dtoCoaches = DeserializeIt<ImportCoachDto>(xmlString, "Coaches");
            StringBuilder sb = new StringBuilder();
            List<Coach> validCoaches = new List<Coach>();
            foreach (ImportCoachDto cDto in dtoCoaches)
            {
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Coach c = new Coach()
                {
                    Name = cDto.Name,
                    Nationality = cDto.Nationality,
                    
                };
                foreach (var fDto in cDto.Footballers)
                {
                    if (!IsValid(fDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime contractStartDate;
                    bool isContractStartDateValid = DateTime.TryParseExact(fDto.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out contractStartDate);
                    if (!isContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime contractEndDate;
                    bool isContractEndDateValid = DateTime.TryParseExact(fDto.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out contractEndDate);
                    if (!isContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (contractStartDate>contractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (fDto.BestSkillType <0 && fDto.BestSkillType > 4)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (fDto.PositionType < 0 && fDto.PositionType > 3)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    Footballer f = new Footballer()
                    {
                        Name = fDto.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = (BestSkillType)fDto.BestSkillType,
                        PositionType = (PositionType)fDto.PositionType
                    };
                     c.Footballers.Add(f);
                }


                validCoaches.Add(c);
                sb.AppendLine($"Successfully imported coach - {c.Name} with {c.Footballers.Count} footballers.");
            }
            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Team> validTeams = new List<Team>();

            var teams = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            foreach (var team in teams)
            {
                if (!IsValid(team))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team validTeam = new Team()
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    Trophies = team.Trophies,
                    
                };
                
                foreach (var foo in team.Footballers)
                {
                    if (!IsValid(foo))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!context.Footballers.Any(x => x.Id == foo))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validTeam.TeamsFootballers.Add(new TeamFootballer()
                    {
                        FootballerId = foo,
                        TeamId = validTeam.Id
                    });
                    
                }

                validTeams.Add(validTeam);
                sb.AppendLine($"Successfully imported team - {validTeam.Name} with {validTeam.TeamsFootballers.Count} footballers.");
            }

            context.Teams.AddRange(validTeams);
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
