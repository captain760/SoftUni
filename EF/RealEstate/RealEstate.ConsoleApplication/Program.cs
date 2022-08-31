using AutoMapper;
using Microsoft.EntityFrameworkCore;

using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Models;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RealEstates.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //output cyrilic correct to the console
            Console.OutputEncoding = Encoding.Unicode;

            // input cyrilic correct from the console
            Console.InputEncoding = Encoding.Unicode;

            ApplicationDbContext db = new ApplicationDbContext();
            db.Database.Migrate();

            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("3. Average Price per square meter");
                Console.WriteLine("4. Add tag");
                Console.WriteLine("5. Bulk tag to properties");
                Console.WriteLine("6. Generate Top Properties Report");
                Console.WriteLine("0. EXIT");
                bool isValid = int.TryParse(Console.ReadLine(), out int option);
                if (isValid && option>=0 && option<=6)
                {
                    switch (option)
                    {
                        case 1:
                            {
                                PropertySearch(db);                                
                                break;
                            }
                        case 2:
                            {                                
                                MostExpensiveDistricts(db);
                                break;
                            }
                        case 3:
                            {
                                AveragePricePerSqMeter(db);
                                break;
                            }
                        case 4:
                            {
                                AddTag(db);
                                break;
                            }
                        case 5:
                            {
                                BulkTag(db);
                                break;
                            }
                        case 6:
                            {
                                FullReport(db);
                                break;
                            }
                        case 0:
                            return;
                            
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void FullReport(ApplicationDbContext db)
        {
            Console.Write("How many Properties to show?: ");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService service = new PropertyService(db);
            var props = service.GetFulldata(count).ToArray();
            //XML export

            var xmlSerializer = new XmlSerializer(typeof(PropertyInfoFullData[]));
            
            var stringWriter = new StringWriter();
           var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true });
            xmlSerializer.Serialize(xmlWriter,props);

            Console.WriteLine(stringWriter.ToString().TrimEnd());

        }

        private static void BulkTag(ApplicationDbContext db)
        {
            Console.WriteLine("Bulk operation started!");
            IPropertiesService propertiesService = new PropertyService(db);
            ITagService tagService = new TagService(db,propertiesService);
            tagService.BulkTagToProperties();
            Console.WriteLine("Bulk operation completed!");
        }

        private static void AddTag(ApplicationDbContext db)
        {
            Console.WriteLine("Tag Name:");
            string tagName = Console.ReadLine();
            Console.WriteLine("Importance:");                        
            bool isParsed= int.TryParse(Console.ReadLine(), out int tagImportance);
            int? importance = isParsed ? tagImportance:null;
            IPropertiesService propertiesService = new PropertyService(db);
            ITagService tagService = new TagService(db,propertiesService);
            tagService.Add(tagName, importance);
        }

        private static void AveragePricePerSqMeter(ApplicationDbContext db)
        {
            var propService = new PropertyService(db);
            Console.WriteLine($"Average price per square meter ---> {propService.AveragePrice():f2} €/m²");
        }

        private static void MostExpensiveDistricts(ApplicationDbContext context)
        {
            Console.Write("How many Districts to show?: ");
            int count = int.Parse(Console.ReadLine());
            IDistrictService service = new DistrictService(context);
            var districts = service.GetMostExpensiveDistricts(count);
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} ==> {district.AveragePricePersquareMeter:f2}€/m² ({district.PropertyCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext context)
        {
            Console.Write("minPrice = ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("maxPrice = ");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("minSize = ");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("maxSize = ");
            int maxSize = int.Parse(Console.ReadLine());
            IPropertiesService service = new PropertyService(context);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);
            foreach (var prop in properties)
            {
                Console.WriteLine($"{prop.DistrictName}; {prop.PropertyType}; {prop.BuildingType} ==> {prop.Price}€ --> {prop.Size}m²");
            }
        }
    }
}