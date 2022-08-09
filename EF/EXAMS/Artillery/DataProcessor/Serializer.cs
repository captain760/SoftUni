
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context
                .Shells.Where(x => x.ShellWeight > shellWeight)
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                            .Where(q=>q.GunType == Data.Models.Enums.GunType.AntiAircraftGun)
                            .Select(y => new
                            {
                                GunType = y.GunType.ToString(),
                                GunWeight = y.GunWeight,
                                BarrelLength = y.BarrelLength,
                                Range = y.Range > 3000 ? "Long-range" : "Regular range",
                            })
                            .OrderByDescending(w => w.GunWeight)
                            .ToList()
                })
                .OrderBy(w => w.ShellWeight)
                .ToList();
            string json = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            List<ExportGunDto> gunsDto = context
                .Guns
                .Where(q => q.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new ExportGunDto
                {
                    ManufacturerName = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                            .Where(y=>y.Country.ArmySize>4500000)
                            .OrderBy(a=>a.Country.ArmySize)
                            .Select(m => new CountryDto()
                                {
                                     CountryName = m.Country.CountryName,
                                     ArmySize = m.Country.ArmySize
                                 })
                            .ToList()
                })
                .OrderBy(n => n.BarrelLength)
                .ToList();

            string result = SerializeIt<ExportGunDto>(gunsDto, "Guns");
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
