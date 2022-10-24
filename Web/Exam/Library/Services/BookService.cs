using Microsoft.EntityFrameworkCore;

using Library.Contracts;
using Library.Data;
using Library.Data.Entities;
using Library.Models;


namespace Library.Services
{
    public class BookService:IBookService
    {
        private readonly LibraryDbContext context;
        public BookService(LibraryDbContext _context)
        {
            this.context = _context;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var entity = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users
                .Include(u => u.ApplicationUsersBooks)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException(Data.DataConstants.User.ErrorUserId);

            }

            var book = await context.Books.FirstOrDefaultAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException(Data.DataConstants.Book.ErrorBookId);
            }

            //checking if the book is already added to the collection of the user
            if (!user.ApplicationUsersBooks.Any(m => m.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUserId = userId                    
                });
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var entities = await context.Books
                 .Include(m => m.Category)
                 .ToListAsync();

            return entities.Select(m => new BookViewModel
            {
                Id = m.Id,
                Author = m.Author,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,
                Category = m.Category.Name
            });
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetMineAsync(string userId)
        {
            var user = await context.Users
                 .Where(u => u.Id == userId)
                 .Include(ub => ub.ApplicationUsersBooks)
                 .ThenInclude(ub => ub.Book)
                 .ThenInclude(b => b.Category)
                 .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new ArgumentException(Data.DataConstants.User.ErrorUserId);
            }
            return user.ApplicationUsersBooks
                .Select(b => new BookViewModel()
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,                   
                    Description = b.Book.Description,
                    ImageUrl = b.Book.ImageUrl,
                    Rating = b.Book.Rating,
                    Category = b.Book.Category.Name 
                });
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users
                  .Where(u => u.Id == userId)
                  .Include(ub => ub.ApplicationUsersBooks)
                  .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new ArgumentException(Data.DataConstants.User.ErrorUserId);
            }
            var book = user.ApplicationUsersBooks.FirstOrDefault(u => u.BookId == bookId);
            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);
                await context.SaveChangesAsync();
            }
        }
    }
}
