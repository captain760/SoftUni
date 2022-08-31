namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var crazyAuthors = context
               .Authors               
               .Select(x => new
               {
                   AuthorName = x.FirstName+" "+x.LastName,
                   Books = x.AuthorsBooks                   
                   .OrderByDescending(n => n.Book.Price)                   
                   .Select(y => new
                   {
                       BookName = y.Book.Name,                       
                       BookPrice = y.Book.Price.ToString("f2")
                   })
                   .ToArray()
               })
               .ToList()
               .OrderByDescending(k => k.Books.Count())
               .ThenBy(i => i.AuthorName)
               .ToArray();
            string json = JsonConvert.SerializeObject(crazyAuthors, Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            Genre reqGenre = (Genre)Enum.Parse(typeof(Genre), "Science");
            List<ExportBookDto> booksDto = context
               .Books
               .Where(q => q.PublishedOn<date && q.Genre == reqGenre)
               .ToList()
               .OrderByDescending(p => p.Pages)
               .ThenByDescending(i => i.PublishedOn)
               .Take(10)
               .Select(x => new ExportBookDto
               {
                   Pages = x.Pages,
                   Name = x.Name,
                   PublishedOn = x.PublishedOn.ToString("d",CultureInfo.InvariantCulture)
               })   
               
               .ToList();
            string result = SerializeIt<ExportBookDto>(booksDto, "Books");
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