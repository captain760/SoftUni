using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService

    {
        private readonly WatchlistDbContext context;
        public MovieService(WatchlistDbContext _context)
        {
            this.context = _context;
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var entity = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };
            await context.Movies.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
           var user = await context.Users                      
                .Include(u=>u.UsersMovies)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
            if (user==null)
            {
                throw new ArgumentException("Invalid User Id");

            }
            var movie = await context.Movies.FirstOrDefaultAsync(u => u.Id == movieId);
            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie Id");
            }
            if (!user.UsersMovies.Any(m=>m.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movieId,
                    UserId = userId,
                    Movie = movie,
                    User = user
                });
                await context.SaveChangesAsync();
            }
        }
        

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            var entities = await context.Movies
                .Include(m=>m.Genre)
                .ToListAsync();
            return entities.Select(m => new MovieViewModel
            {
                Director = m.Director,
                Title = m.Title,
                Id = m.Id,
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,  
                Genre = m.Genre.Name
            });
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                 .Where(u => u.Id == userId)
                 .Include(um => um.UsersMovies)
                 .ThenInclude(um => um.Movie)
                 .ThenInclude(m => m.Genre)
                 .FirstOrDefaultAsync();
            if (user==null)
            {
                throw new ArgumentException("Invalid user Id");
            }
            return user.UsersMovies
                .Select(m => new MovieViewModel()
                {
                    Director = m.Movie.Director,
                    Genre = m.Movie.Genre.Name,
                    Id = m.Movie.Id,
                    Title = m.Movie.Title,
                    ImageUrl = m.Movie.ImageUrl,
                    Rating = m.Movie.Rating
                });
        }

        public async Task RemoveFromCollectionAsync(int movieId, string userId)
        {
            var user = await context.Users
                  .Where(u => u.Id == userId)
                  .Include(um => um.UsersMovies)                  
                  .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }
            var movie = user.UsersMovies.FirstOrDefault(u => u.MovieId == movieId);
            if (movie != null)
            {
                user.UsersMovies.Remove(movie);
                await context.SaveChangesAsync();
            }
        }
    }
}
