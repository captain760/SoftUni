namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            List<ImportBooksDto> dtoBooks = DeserializeIt<ImportBooksDto>(xmlString, "Books");
            StringBuilder sb = new StringBuilder();
            List<Book> validBooks = new List<Book>();
            foreach (ImportBooksDto bDto in dtoBooks)
            {
                if (!IsValid(bDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                
                if (bDto.Genre<1 || bDto.Genre>3)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime purDate;
                bool isPurDateValid = DateTime.TryParseExact(bDto.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out purDate);
                if (!isPurDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Book b = new Book()
                {
                    Name = bDto.Name,
                    Genre = (Genre)bDto.Genre,
                    Price = bDto.Price,
                    Pages = bDto.Pages,
                    PublishedOn = purDate
                    
                };
                validBooks.Add(b);
                sb.AppendLine(String.Format(SuccessfullyImportedBook,b.Name,b.Price));
            }
            context.Books.AddRange(validBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var authors = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);
            List<Author> validAuthors = new List<Author>();
            List<string> emails = new List<string>();
            foreach (var author in authors)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (emails.Contains(author.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Author validAuthor = new Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Email = author.Email,
                    Phone = author.Phone
                };
                if (!author.Books.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var bId in author.Books)
                {
                    if (!context.Books.Any(x=>x.Id == bId.Id) || bId == null)
                    {
                         continue;
                    }
                    
                    AuthorBook ab = new AuthorBook()
                    {
                        BookId = (int)bId.Id
                    };

                    validAuthor.AuthorsBooks.Add(ab);
                }
                if (validAuthor.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                emails.Add(author.Email);
                validAuthors.Add(validAuthor);
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor,$"{validAuthor.FirstName} {validAuthor.LastName}",validAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(validAuthors);
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