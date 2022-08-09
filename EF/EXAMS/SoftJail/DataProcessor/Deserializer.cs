namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            List<Department> validDepartments = new List<Department>();

            foreach (ImportDepartmentDto departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                if (!departmentDto.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                
                if (departmentDto.Cells.Any(x=>!IsValid(x)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name
                    
                };
                
                foreach (ImportCellDto cellDto in departmentDto.Cells)
                {
                    
                    department.Cells.Add(new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }               

                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerWithMailDto[] prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonerWithMailDto[]>(jsonString);

            List<Prisoner> validPrisoners = new List<Prisoner>();
            foreach (ImportPrisonerWithMailDto prDto in prisonersDtos)
            {
                if (!IsValid(prDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                if (prDto.Mails.Any(x=>!IsValid(x.Address)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);
                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(prDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseDateValid = DateTime.TryParseExact(prDto.ReleaseDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);
                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    releaseDate = releaseDateValue;
                }
                Prisoner p = new Prisoner()
                {
                    FullName = prDto.FullName,
                    Nickname = prDto.Nickname,
                    Age = prDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prDto.Bail,
                    CellId = prDto.CellId
                };
                foreach (var mail in prDto.Mails)
                {
                    p.Mails.Add(new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    });
                }
                validPrisoners.Add(p);
                sb.AppendLine($"Imported {p.FullName} {p.Age} years old");
            }
            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            List<ImportOfficerWithPrisonersDto> dtoOfficers = DeserializeIt<ImportOfficerWithPrisonersDto>(xmlString, "Officers");
            StringBuilder sb = new StringBuilder();
            List<Officer> validOfficers = new List<Officer>();
            foreach (ImportOfficerWithPrisonersDto offDto in dtoOfficers)
            {
                if (!IsValid(offDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                
                bool isPosValid = Enum.TryParse(typeof(Position),offDto.Position,out object posObj);
                if (!isPosValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                bool isWepValid = Enum.TryParse(typeof(Weapon), offDto.Weapon, out object wepObj);
                if (!isWepValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                //if (!context.Departments.Any(x=>x.Id==offDto.DepartmentId))
                //{
                //    sb.AppendLine("Invalid Data");
                //    continue;
                //}

                Officer o = new Officer()
                {
                    FullName = offDto.FullName,
                    Salary = offDto.Salary,
                    Position =(Position) posObj,
                    Weapon = (Weapon) wepObj,
                    DepartmentId = offDto.DepartmentId,
                };
                foreach (var pDto in offDto.Prisoners)
                {
                    OfficerPrisoner op = new OfficerPrisoner()
                    {
                        Officer = o,
                        PrisonerId = pDto.Id
                    };
                    o.OfficerPrisoners.Add(op);
                }


                validOfficers.Add(o);
                sb.AppendLine($"Imported {o.FullName} ({o.OfficerPrisoners.Count} prisoners)");
            }
            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
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