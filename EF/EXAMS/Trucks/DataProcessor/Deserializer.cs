namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            List<ImportDespatcherDto> dtoDespatchers = DeserializeIt<ImportDespatcherDto>(xmlString, "Despatchers");
            StringBuilder sb = new StringBuilder();
            List<Despatcher> validDespatchers = new List<Despatcher>();
            foreach (ImportDespatcherDto dDto in dtoDespatchers)
            {
                if (!IsValid(dDto) )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (String.IsNullOrEmpty(dDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher d = new Despatcher()
                {
                    Name = dDto.Name,
                    Position = dDto.Position
                };
                foreach (var tDto in dDto.Trucks)
                {
                    if (!IsValid(tDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }                                     

                    if (tDto.CategoryType < 0 || tDto.CategoryType > 3)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (tDto.MakeType < 0 || tDto.MakeType > 4)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck t = new Truck()
                    {
                        RegistrationNumber = tDto.RegistrationNumber,
                        VinNumber = tDto.VinNumber,
                        TankCapacity = tDto.TankCapacity,
                        CargoCapacity = tDto.CargoCapacity,
                        CategoryType = (CategoryType)tDto.CategoryType,
                        MakeType = (MakeType)tDto.MakeType
                    };
                    d.Trucks.Add(t);
                }

                validDespatchers.Add(d);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, d.Name, d.Trucks.Count));
            }
            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Client> validClients = new List<Client>();
            //List<int> validTrucks = new List<int>();

            var clients = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            foreach (var client in clients)
            {
                if (!IsValid(client))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (client.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client validClient = new Client()
                {
                    Name = client.Name,
                    Nationality = client.Nationality,
                    Type = client.Type

                };

                foreach (var t in client.Trucks.Distinct())
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    if (!context.Trucks.Any(x => x.Id == t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validClient.ClientsTrucks.Add(new ClientTruck()
                    {
                        TruckId = t,
                        ClientId = validClient.Id
                    });

                }

                validClients.Add(validClient);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, validClient.Name, validClient.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
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
