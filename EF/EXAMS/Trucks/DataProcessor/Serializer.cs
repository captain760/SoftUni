namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            List<ExportDespatchersDto> despatchersDto = context
                 .Despatchers
                 .Where(q => q.Trucks.Count > 0)
                 .ToList()
                 .Select(x => new ExportDespatchersDto
                 {
                     TruckCount = x.Trucks.Count,
                     Name= x.Name,
                     Trucks = x.Trucks
                     .OrderBy(x => x.RegistrationNumber)
                     .Select(m => new Trucks()
                     {
                         RegistrationNumber = m.RegistrationNumber,
                         MakeType = m.MakeType.ToString()
                     })
                     .ToList()
                 })
                 .OrderByDescending(n => n.TruckCount)
                 .ThenBy(i => i.Name)
                 .ToList();
            string result = SerializeIt<ExportDespatchersDto>(despatchersDto, "Despatchers");
            return result;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var ClientsTrucks = context
               .Clients              
               .Where(i => i.ClientsTrucks.Any(f => f.Truck.TankCapacity >= capacity))
               .ToArray()
               .Select(x => new
               {
                   Name = x.Name,
                   Trucks = x.ClientsTrucks
                   .Where(c => c.Truck.TankCapacity >= capacity)
                   .OrderBy(n => n.Truck.MakeType)
                   .ThenByDescending(n => n.Truck.CargoCapacity)
                   .Select(y => new
                   {
                       TruckRegistrationNumber = y.Truck.RegistrationNumber,
                       VinNumber = y.Truck.VinNumber,
                       TankCapacity = y.Truck.TankCapacity,
                       CargoCapacity = y.Truck.CargoCapacity,
                       CategoryType = y.Truck.CategoryType.ToString(),
                       MakeType = y.Truck.MakeType.ToString(),

                   })

               })
               .OrderByDescending(k => k.Trucks.Count())
               .ThenBy(i => i.Name)
               .Take(10)
               .ToArray();
            string json = JsonConvert.SerializeObject(ClientsTrucks, Formatting.Indented);
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
