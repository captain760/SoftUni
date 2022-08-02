namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            //DbInitializer.ResetDatabase(context);
            //Problem 02
            //string cmd = Console.ReadLine().ToLower();
            //Console.WriteLine(GetBooksByAgeRestriction(context, cmd));
            //Problem 03
            //Console.WriteLine(GetGoldenBooks(context));
            //Problem 04
            //Console.WriteLine(GetBooksByPrice(context));
            //Problem 05
            //int missedYear = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(context, missedYear));
            //Problem 06
            //string catValues = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(context,catValues.ToLower()));
            //Problem 07
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(context,date));
            //Problem 08
            //string str = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(context, str));
            //Problem 09
            //string str = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(context, str));
            //Problem 10
            //string str = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(context, str));
            //Problem 11
            //int lngth = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(context,lngth));
            //Problem 12
            //Console.WriteLine(CountCopiesByAuthor(context));
            //Problem 13
            //Console.WriteLine(GetTotalProfitByCategory(context));
            //Problem 14
            //Console.WriteLine(GetMostRecentBooks(context));
            //Problem 15
            //IncreasePrices(context);
            //Problem 16
            Console.WriteLine(RemoveBooks(context));

        }
        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            
            AgeRestriction ageRestriction = new AgeRestriction();
            bool hasParsed = Enum.TryParse<AgeRestriction>(command,true,out ageRestriction);
            if (!hasParsed)
            {
                return String.Empty;
            }
            var agedBooks = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b=>b.Title)
                .OrderBy(b => b)
                .ToArray();
            string result = String.Join(Environment.NewLine, agedBooks);
            
            
            return result.ToString().TrimEnd();
        }
        //Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context
                .Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b =>b.Title)                
                .ToArray();
            string res = String.Join(Environment.NewLine, goldenBooks);
            return res.ToString();
        }
        //Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var priceBooks = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var book in priceBooks)
            {
                sb.AppendLine($"{book.Title}  -  ${book.Price}");
            }

            return sb.ToString().TrimEnd();

        }
        //Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var unreleasedBooks = context
                .Books
                .OrderBy(b => b.BookId)
                .ToArray()
                .Where(b=>b.ReleaseDate.Value.Year!=year)
                //.Where(b => DateTime.Parse(b.ReleaseDate.ToString()).Year != year)
                .Select(b => b.Title)
                .ToArray();
                
            var sb = new StringBuilder();
            foreach(var book in unreleasedBooks)
            {
                sb.AppendLine(book);
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] cats = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var catBook = context
                .Books
                .Where(b => b.BookCategories.Any(x=>cats.Contains(x.Category.Name.ToLower())))                
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();
            return String.Join(Environment.NewLine, catBook);
        }
        //Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime limitDate = DateTime.ParseExact(date, "dd-MM-yyyy",CultureInfo.InvariantCulture);
            
            var earlyBooks = context
                .Books
                .ToList()
                .Where(b => b.ReleaseDate.Value < limitDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in earlyBooks)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var chosenAuthors = context
                .Authors
                .ToArray()
                .Where(a=>a.FirstName.ToString().EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a=>a.FirstName)
                .ThenBy(a=>a.LastName)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var author in chosenAuthors)
            {
                string fullName = $"{author.FirstName} {author.LastName}";
                sb.AppendLine(fullName);
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var serchedBooks = context
                .Books
                .ToArray()
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();
            return String.Join(Environment.NewLine,serchedBooks).ToString().TrimEnd();
        }
        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context
                .Books                
                .ToArray()
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName,

                })
                .ToArray();
            var sb = new StringBuilder();
            foreach (var Book in booksByAuthor)
            {
                sb.AppendLine($"{Book.Title} ({Book.FirstName} {Book.LastName})");
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var longBooks = context
                .Books
                .Where(b => b.Title.Length > lengthCheck).
                Select(b => b.BookId)
                .ToArray();
            return longBooks.Length;
        }
        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsWithCopies = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var author in authorsWithCopies)
            {
                sb.AppendLine($"{author.AuthorName} - {author.BookCopies}");
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var catProf = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks
                            .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var cat in catProf)
            {
                sb.AppendLine($"{cat.Name} ${cat.Profit:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recent = context
                .Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate.Value)
                    .Select(rb=> new
                    {
                        BookTitle = rb.Book.Title,
                        BookYear = rb.Book.ReleaseDate.Value.Year
                    }                        )
                    .Take(3)
                })
                
                .ToArray();
            var sb = new StringBuilder();
            foreach (var item in recent)
            {
                sb.AppendLine($"--{item.Name}");
                foreach (var book in item.RecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookYear})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            IQueryable<Book> bookBeforeYear = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);
            foreach (var book in bookBeforeYear)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }
        //Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            IQueryable<Book> booksToDelete = context
                .Books
                .Where(b => b.Copies < 4200);
            int deleted = 0;
            foreach (var book in booksToDelete)
            {
                context.Remove(book);
                deleted++;
            }
            context.SaveChanges();

            return deleted;
        }
    }
}
