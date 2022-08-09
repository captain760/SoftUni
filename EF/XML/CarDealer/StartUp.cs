using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static string filePath;
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //Console.WriteLine("Database successfully created!!!");

            //Problem 09
            //InitializeDatasetsFilePath("suppliers.xml");
            //string InputXml = File.ReadAllText(filePath);
            //string output = ImportSuppliers(context, InputXml);
            //Console.WriteLine(output);

            //Problem 10
            //InitializeDatasetsFilePath("parts.xml");
            //string InputXml = File.ReadAllText(filePath);
            //string output = ImportParts(context, InputXml);
            //Console.WriteLine(output);

            //Problem 11
            //InitializeDatasetsFilePath("cars.xml");
            //string InputXml = File.ReadAllText(filePath);
            //string output = ImportCars(context, InputXml);
            //Console.WriteLine(output);

            //Problem 12
            //InitializeDatasetsFilePath("customers.xml");
            //string InputXml = File.ReadAllText(filePath);
            //string output = ImportCustomers(context, InputXml);
            //Console.WriteLine(output);

            //Problem 13
            //InitializeDatasetsFilePath("sales.xml");
            //string InputXml = File.ReadAllText(filePath);
            //string output = ImportSales(context, InputXml);
            //Console.WriteLine(output);

            //Problem 14
            //InitializeOutputFilePath("cars.xml");
            //string xml = GetCarsWithDistance(context);
            //File.WriteAllText(filePath, xml);

            //Problem 15
            //InitializeOutputFilePath("bmw-cars.xml");
            //string xml = GetCarsFromMakeBmw(context);
            //File.WriteAllText(filePath, xml);

            //Problem 16
            //InitializeOutputFilePath("local-suppliers.xml");
            //string xml = GetLocalSuppliers(context);
            //File.WriteAllText(filePath, xml);

            //Problem 17
            //InitializeOutputFilePath("cars-and-parts.xml");
            //string xml = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText(filePath, xml);

            //Problem 18
            //InitializeOutputFilePath("customers-total-sales.xml");
            //string xml = GetTotalSalesByCustomer(context);
            //File.WriteAllText(filePath, xml);

            //Problem 19
            InitializeOutputFilePath("sales-discounts.xml");
            string xml = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(filePath, xml);
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            List<ImportSupplierDTO> dtoSuppliers = DeserializeIt<ImportSupplierDTO>(inputXml, "Suppliers");
            ICollection<Supplier> suppliers = new List<Supplier>();
            InitializeAutoMapper();
            foreach (var sDTO in dtoSuppliers)
            {
                if (!IsValid(sDTO))
                {
                    continue;
                }
                Supplier supplier = mapper.Map<Supplier>(sDTO);
                suppliers.Add(supplier);
            }
            
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            List<ImportPartDTO> dtoParts = DeserializeIt<ImportPartDTO>(inputXml, "Parts");
            List<int> supIds = context.Suppliers.Select(s => s.Id).ToList();
            
            InitializeAutoMapper();

            IEnumerable<Part> parts = mapper.Map<IEnumerable<Part>>(dtoParts).Where(x => supIds.Contains(x.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";

        }
        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            List<ImportCarDTO> dtoCars = DeserializeIt<ImportCarDTO>(inputXml, "Cars");
            List<int> existingPartsIDs = context.Parts.Select(p => p.Id).ToList();
            List<Car> cars = new List<Car>();
            foreach (var cDTO in dtoCars)
            {
                Car newCar = new Car
                {
                    Make = cDTO.Make,
                    Model = cDTO.Model,
                    TravelledDistance = cDTO.TravelledDistance
                };
                foreach (var partId in cDTO.PartsIds)
                {
                    if (!existingPartsIDs.Contains(partId.PartId))
                    {
                        continue;
                    }
                    newCar.PartCars.Add(new PartCar
                    {
                        PartId = partId.PartId
                    });
                }
                cars.Add(newCar);
            }
            //List<Car> cars = dtoCars.Select(x => new Car
            //{
            //    Make = x.Make,
            //    Model = x.Model,
            //    TravelledDistance = x.TravelledDistance,
            //    PartCars = x.PartsIds.Select(x => x.PartId).Intersect(existingPartsIDs).Distinct()
            //    .Select(y => new PartCar
            //    {
            //        PartId = y
            //    })
            //     .ToList(),
            //})
            //.ToList();
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            List<ImportCustomerDTO> dtoCustomers = DeserializeIt<ImportCustomerDTO>(inputXml, "Customers");
            ICollection<Customer> customers = new List<Customer>();
            InitializeAutoMapper();
            foreach (var cDTO in dtoCustomers)
            {
                if (!IsValid(cDTO))
                {
                    continue;
                }
                Customer customer = mapper.Map<Customer>(cDTO);
                customers.Add(customer);
            }
                    
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            List<ImportSaleDTO> dtoSales = DeserializeIt<ImportSaleDTO>(inputXml, "Sales");
            List<int> carIds = context.Cars.Select(x=>x.Id).ToList();
            ICollection<Sale> sales = new List<Sale>();
            InitializeAutoMapper();
            foreach (var sDTO in dtoSales)
            {
                if (!IsValid(sDTO) || !carIds.Contains(sDTO.CarId))
                {
                    continue;
                }
                Sale sale = mapper.Map<Sale>(sDTO);
                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<ExportCarDTO> dtoCars = mapper.Map<List<ExportCarDTO>>(context.Cars);

            List<ExportCarDTO> cars = dtoCars.Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            string result = SerializeIt<ExportCarDTO>(cars, "cars");
            return result;
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<ExportBMWCarsDTO> dtoBMWCars = mapper.Map<List<ExportBMWCarsDTO>>(context.Cars.Where(x=>x.Make == "BMW"));

            List<ExportBMWCarsDTO> cars = dtoBMWCars
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            string result = SerializeIt<ExportBMWCarsDTO>(cars, "cars");
            return result;
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<ExportSupplierDTO> dtoSuppliers = mapper.Map<List<ExportSupplierDTO>>(context.Suppliers.Include(x=>x.Parts).Where(s=>s.IsImporter ==false)).ToList();

            
                

            string result = SerializeIt<ExportSupplierDTO>(dtoSuppliers, "suppliers");
            return result;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            List<ExportCarWithPartsDTO> dtoCarsParts = context.Cars.Select(x => new ExportCarWithPartsDTO
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TravelledDistance,
                PartsInner = x.PartCars.Select(p => new ExportCarPartsInnerDTO
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price

                })
                .OrderByDescending(x => x.Price)
                .ToList()

            })
            .OrderByDescending(x => x.TravelledDistance)
            .ThenBy(x => x.Model)
            .Take(5)
            .ToList();

            string result = SerializeIt<ExportCarWithPartsDTO>(dtoCarsParts, "cars");
            return result;
        }


        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            List<ExportSalesCustomersDTO> dtoCustomers = context
                .Customers
                .Where(s => s.Sales.Count > 0)
                .Select(x => new ExportSalesCustomersDTO
                {
                    Name = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Select(s=>s.Car).SelectMany(s=>s.PartCars).Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            string result = SerializeIt<ExportSalesCustomersDTO>(dtoCustomers, "customers");
            return result;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            List<ExportSalesDiscountDTO> sales = context
                .Sales
                .Select(x => new ExportSalesDiscountDTO
                {
                    Car = new ExportCar2DTO
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    Name = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x=>x.Part.Price),
                    DiscountedPrice = x.Car.PartCars.Sum(x=>x.Part.Price)*(1-x.Discount/100)
                })
                .ToList();
                

            string result = SerializeIt<ExportSalesDiscountDTO>(sales, "sales");
            return result;
        }






        private static void InitializeAutoMapper()
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(conf => conf.AddProfile<CarDealerProfile>());

            mapper = mapperConfig.CreateMapper();
        }

        private static List<T> DeserializeIt<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), xmlRootAttribute);

            using StringReader reader = new StringReader(inputXml);

            List<T> DtoT = (List<T>)xmlSerializer.Deserialize(reader);

            return DtoT;
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
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);
            return isValid;

        }
        private static void InitializeDatasetsFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }
        private static void InitializeOutputFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
        }
    }
}