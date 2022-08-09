namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            List<ImportCountryDto> dtoCountries = DeserializeIt<ImportCountryDto>(xmlString, "Countries");
            StringBuilder sb = new StringBuilder();
            List<Country> validCountries = new List<Country>();
            foreach (ImportCountryDto cDto in dtoCountries)
            {
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Country c = new Country()
                {
                    CountryName = cDto.CountryName,
                    ArmySize = cDto.ArmySize,

                };
                
                validCountries.Add(c);
                sb.AppendLine(string.Format(SuccessfulImportCountry,c.CountryName, c.ArmySize)) ;
            }
            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            List<ImportManuDto> dtoManus = DeserializeIt<ImportManuDto>(xmlString, "Manufacturers");
            StringBuilder sb = new StringBuilder();
            List<Manufacturer> validManus = new List<Manufacturer>();
            foreach (ImportManuDto mDto in dtoManus)
            {
                if (!IsValid(mDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Manufacturer m = new Manufacturer()
                {
                    ManufacturerName = mDto.ManufacturerName,
                    Founded = mDto.Founded
                };
                if (validManus.Any(x=>x.ManufacturerName ==m.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validManus.Add(m);
                string[] stringElements = m.Founded
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string cityCountry = $"{stringElements[stringElements.Length-2]}, {stringElements[stringElements.Length-1]}";
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, m.ManufacturerName, cityCountry));
            }
            context.Manufacturers.AddRange(validManus);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            List<ImportShellDto> dtoShells = DeserializeIt<ImportShellDto>(xmlString, "Shells");
            StringBuilder sb = new StringBuilder();
            List<Shell> validShells = new List<Shell>();
            foreach (ImportShellDto sDto in dtoShells)
            {
                if (!IsValid(sDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Shell s = new Shell()
                {
                    ShellWeight = sDto.ShellWeight,
                    Caliber = sDto.Caliber
                };
                
                validShells.Add(s);
                
                sb.AppendLine(string.Format(SuccessfulImportShell, s.Caliber, s.ShellWeight));
            }
            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Gun> validGuns = new List<Gun>();

            var guns = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            foreach (var gun in guns)
            {
                if (!IsValid(gun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.TryParse(typeof(GunType), gun.GunType, out var gunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Gun validGun = new Gun()
                {
                    ManufacturerId = gun.ManufacturerId,
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    NumberBuild = gun.NumberBuild,
                    Range = gun.Range,
                    GunType = (GunType)gunType,
                    ShellId = gun.ShellId,
                    CountriesGuns = new List<CountryGun>()
                };
                foreach (var c in gun.Countries)
                {
                    CountryGun cg = new CountryGun()
                    {
                        CountryId = c.Id
                        //GunId = context.Guns.FirstOrDefault(x => x.ManufacturerId == gun.ManufacturerId && x.Shell.Id == gun.ShellId && x.GunWeight == gun.GunWeight).Id
                    };
                    validGun.CountriesGuns.Add(cg);
                };
                validGuns.Add(validGun);
                sb.AppendLine(String.Format(SuccessfulImportGun,validGun.GunType.ToString(),validGun.GunWeight,validGun.BarrelLength));
            };
            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().Trim();
        }




        private static List<T> DeserializeIt<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), xmlRootAttribute);

            using StringReader reader = new StringReader(inputXml);

            List<T> DtoT = (List<T>)xmlSerializer.Deserialize(reader);

            return DtoT;
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
