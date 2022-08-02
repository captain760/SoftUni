using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.CarsDTO;
using CarDealer.DTO.CustomersDTO;
using CarDealer.DTO.PartsDTO;
using CarDealer.DTO.SalesDTO;
using CarDealer.DTO.SupplierDTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string filePath;
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));
           CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //Console.WriteLine("Database successfully created");

            //Problem 09
            //InitializeDatasetsFilePath("suppliers.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportSuppliers(context, InputJson);
            //Console.WriteLine(output);

            //Problem 10
            //InitializeDatasetsFilePath("parts.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportParts(context, InputJson);
            //Console.WriteLine(output);

            //Problem 11
            //InitializeDatasetsFilePath("cars.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportCars(context, InputJson);
            //Console.WriteLine(output);

            //Problem 12
            //InitializeDatasetsFilePath("customers.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportCustomers(context, InputJson);
            //Console.WriteLine(output);

            //Problem 13
            //InitializeDatasetsFilePath("sales.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportSales(context, InputJson);
            //Console.WriteLine(output);

            //Problem 14
            //InitializeOutputFilePath("ordered-customers.json");
            //string json = GetOrderedCustomers(context);
            //File.WriteAllText(filePath, json);

            //Problem 15
            //InitializeOutputFilePath("toyota-cars.json");
            //string json = GetCarsFromMakeToyota(context);
            //File.WriteAllText(filePath, json);

            //Problem 16
            //InitializeOutputFilePath("local-suppliers.json");
            //string json = GetLocalSuppliers(context);
            //File.WriteAllText(filePath, json);

            //Problem 17
            //InitializeOutputFilePath("cars-and-parts.json");
            //string json = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText(filePath, json);

            //Problem 18
            //InitializeOutputFilePath("customers-total-sales.json");
            //string json = GetTotalSalesByCustomer(context);
            //File.WriteAllText(filePath, json);

            //Problem 19
            InitializeOutputFilePath("sales-discounts.json");
            string json =GetSalesWithAppliedDiscount(context);
            File.WriteAllText(filePath, json);
        }




        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplierDTO[] supplierDTOs = JsonConvert.DeserializeObject<ImportSupplierDTO[]>(inputJson);
            ICollection<Supplier> suppliers = new List<Supplier>();
            foreach (ImportSupplierDTO sDTO in supplierDTOs)
            {
                if (!IsValid(sDTO))
                {
                    continue;
                }
                Supplier supplier = Mapper.Map<Supplier>(sDTO);
                suppliers.Add(supplier);
            }
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ImportPartsDTO[] partDTOs = JsonConvert.DeserializeObject<ImportPartsDTO[]>(inputJson);
            ICollection<Part> parts = new List<Part>();
            List<int> supId = context.Suppliers.Select(s => s.Id).ToList();
            foreach (ImportPartsDTO pDTO in partDTOs)
            {
                if (!IsValid(pDTO)|| !supId.Contains(pDTO.SupplierId))
                {
                    continue;
                }
                Part part = Mapper.Map<Part>(pDTO);
                parts.Add(part);
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IEnumerable<ImportCarDTO> CarDTOs = JsonConvert.DeserializeObject<IEnumerable<ImportCarDTO>>(inputJson);
            ICollection<Car> cars = new List<Car>();
            foreach (ImportCarDTO cDTO in CarDTOs)
            {
                if (!IsValid(cDTO))
                {
                    continue;
                }
                Car newCar =new Car
                {
                    Make = cDTO.Make,
                    Model = cDTO.Model,
                    TravelledDistance = cDTO.TravelledDistance
                };
                foreach (int partId in cDTO.PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar { PartId = partId });
                }
                cars.Add(newCar);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomerDTO[] customerDTOs = JsonConvert.DeserializeObject<ImportCustomerDTO[]>(inputJson);
            ICollection<Customer> customers = new List<Customer>();
            
            foreach (ImportCustomerDTO cDTO in customerDTOs)
            {
                if (!IsValid(cDTO) )
                {
                    continue;
                }
                Customer customer = Mapper.Map<Customer>(cDTO);
                customers.Add(customer);
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ImportSaleDTO[] saleDTOs = JsonConvert.DeserializeObject<ImportSaleDTO[]>(inputJson);
            ICollection<Sale> sales = new List<Sale>();

            foreach (ImportSaleDTO sDTO in saleDTOs)
            {
                if (!IsValid(sDTO))
                {
                    continue;
                }
                Sale sale = Mapper.Map<Sale>(sDTO);
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            ExportLocalSuppDTO[] customers = context
                .Customers
                .OrderBy(b => b.BirthDate)
                .ThenBy(b => b.IsYoungDriver)
                .ProjectTo<ExportLocalSuppDTO>()
                .ToArray();
            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            ExportToyotaCarDTO[] toyotaCars = context
                .Cars
                .Where(mk=>mk.Make == "Toyota")
                .OrderBy(md => md.Model)
                .ThenByDescending(td => td.TravelledDistance)
                .ProjectTo<ExportToyotaCarDTO>()
                .ToArray();
            string json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return json;
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSupps = context
                            .Suppliers
                            .Where(i => i.IsImporter == false)
                            .Select(x => new
                            {
                                Id = x.Id,
                                Name = x.Name,
                                PartsCount = x.Parts.Count
                            })
                            .ToArray();
            string json = JsonConvert.SerializeObject(localSupps, Formatting.Indented);
            return json;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context
                .Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },
                    parts = x.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                })
                .ToArray();
            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var custs = context
                .Customers
                .Where(x => x.Sales.Count > 0)
                .ToArray()
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(s=>s.spentMoney)
                .ThenByDescending(c=>c.boughtCars)
                .ToArray();
            return JsonConvert.SerializeObject(custs, Formatting.Indented);
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(s => s.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(s => s.Part.Price) * (1-(x.Discount)/100)).ToString("f2")
                })
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);

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