using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

using System.Linq;
using ProductShop.Data;
using ProductShop.DTOs.CategoryDTO;
using ProductShop.DTOs.CategoryProductDTO;
using ProductShop.DTOs.ProductDTO;
using ProductShop.DTOs.UserDTO;
using ProductShop.Models;

using AutoMapper;
using Newtonsoft.Json;
using AutoMapper.QueryableExtensions;

namespace ProductShop
{
    public class StartUp
    {
        private static string filePath;  
        public static void Main(string[] args)
        {
            
            Mapper.Initialize(cfg=>cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //Console.WriteLine("Database successfully created");

            //Problem 01
            //InitializeFilePath("users.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportUsers(context, InputJson);
            //Console.WriteLine(output);

            //Problem 02
            //InitializeFilePath("products.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportProducts(context, InputJson);
            //Console.WriteLine(output);

            //Problem 03
            //InitializeFilePath("categories.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportCategories(context, InputJson);
            //Console.WriteLine(output);

            //Problem 04
            //InitializeFilePath("categories-products.json");
            //string InputJson = File.ReadAllText(filePath);
            //string output = ImportCategoryProducts(context, InputJson);
            //Console.WriteLine(output);

            //Problem 05
            //InitializeOutputFilePath("products-in-range.json");
            //string json = GetProductsInRange(context);
            //File.WriteAllText(filePath,json);

            //Problem 06
            //InitializeOutputFilePath("users-sold-products.json");
            //string json = GetSoldProducts(context);
            //File.WriteAllText(filePath, json);

            //Problem 07
            //InitializeOutputFilePath("categories-by-products.json");
            //string json = GetCategoriesByProductsCount(context);
            //File.WriteAllText(filePath, json);

            //Problem 08
            InitializeOutputFilePath("users-and-products.json");
            string json = GetUsersWithProducts(context);
            File.WriteAllText(filePath, json);
        }
        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDTO[] userDTOs = JsonConvert.DeserializeObject < ImportUserDTO[]>(inputJson);
            ICollection<User> users = new List<User>();
            foreach (ImportUserDTO uDTO in userDTOs)
            {
                if (!IsValid(uDTO))
                {
                    continue;
                }
                User user = Mapper.Map<User>(uDTO);
                users.Add(user);
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDTO[] productDTOs = JsonConvert.DeserializeObject< ImportProductDTO[]>(inputJson);
            ICollection<Product> validProducts = new List<Product>();
            foreach (ImportProductDTO pDTO in productDTOs)
            {
                if (!IsValid(pDTO))
                {
                    continue;
                }
                Product product = Mapper.Map<Product>(pDTO);
                validProducts.Add(product);
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }
        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDTO[] categoryDTOs = JsonConvert.DeserializeObject<ImportCategoryDTO[]>(inputJson);
            ICollection<Category> validCategories = new List<Category>();
           
            foreach (ImportCategoryDTO cDTO in categoryDTOs)
            {
                if (!IsValid(cDTO) || cDTO.Name==null)
                {
                    continue;
                }
                Category category = Mapper.Map<Category>(cDTO);
                validCategories.Add(category);
                
            }
            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDTO[] categoryProductDTOs = JsonConvert.DeserializeObject<ImportCategoryProductDTO[]>(inputJson);
            ICollection<CategoryProduct> validCategoryProducts = new List<CategoryProduct>();

            foreach (ImportCategoryProductDTO cpDTO in categoryProductDTOs)
            {
                if (!IsValid(cpDTO) )
                {
                    continue;
                }
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(cpDTO);
                validCategoryProducts.Add(categoryProduct);

            }
            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                //manual mapping !!!!
                //.Select(p => new
                //{
                //    name = p.Name,
                //    price = p.Price,
                //    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                //})
                .ProjectTo<ExportProductInRangeDTO>()
                .ToArray();
            string json = JsonConvert.SerializeObject(productsInRange,Formatting.Indented);
            return json;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUsersWithSoldProductsDTO[] products = context
                .Users
                .Where(p => p.ProductsSold.Any(b => b.BuyerId.HasValue))
                .OrderBy(l => l.LastName)
                .ThenBy(f => f.FirstName)
                .ProjectTo<ExportUsersWithSoldProductsDTO>()
                .ToArray();
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoryByProductCountDTO[] cats = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<ExportCategoryByProductCountDTO>()
                .ToArray();
            string json = JsonConvert.SerializeObject(cats, Formatting.Indented);
            return json;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .Select(s => new ExportUserFullDTO()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age,
                    Products = new ExportUsersProductsDTO()
                    {
                        SoldProducts = s.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new ExportProductShortDTO()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                    }
                })
                .ToArray();
            ExportUserInfoDTO serDTO = new ExportUserInfoDTO()
            {
                UsersCount = users.Length,
                UsersDisplayed = users
            };
            JsonSerializerSettings jsonSettings  = new JsonSerializerSettings()
            { 
                NullValueHandling = NullValueHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(serDTO, Formatting.Indented,jsonSettings);
            return json;    
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj,validationContext,validationResult);
            return isValid;

        }
        private static void InitializeDatasetsFilePath(string fileName)
        {
            filePath =  Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }
        private static void InitializeOutputFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
        }
    }
}