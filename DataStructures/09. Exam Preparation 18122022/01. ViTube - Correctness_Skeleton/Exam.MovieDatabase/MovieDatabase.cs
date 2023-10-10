using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private readonly Dictionary<string, Actor> actors = new Dictionary<string, Actor>();
        private readonly Dictionary<string, Movie> movies = new Dictionary<string, Movie>();
        
        public void AddActor(Actor actor)
        {
			if (!actors.ContainsKey(actor.Id))
			{
            actors[actor.Id] = actor;
			}
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!actors.ContainsKey(actor.Id))
            {
                throw new ArgumentException();
            }
            if (!movies.ContainsKey(movie.Id))
                {
                    movies[movie.Id] = movie;
                }
            actors[actor.Id].Movies.Add(movie);
        }

        public bool Contains(Actor actor)
        {
            return actors.ContainsKey(actor.Id);
        }

        public bool Contains(Movie movie)
        {
           return movies.ContainsKey(movie.Id);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return actors.Values.OrderByDescending(x=>x.Movies.Count>0? x.Movies.Max(x=>x.Budget):0).ThenByDescending(x=>x.Movies.Count);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies.Values;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return movies.Values.Where(x=>x.Budget >= lower && x.Budget <= upper).OrderByDescending(x=>x.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            return movies.Values.OrderByDescending(x => x.Budget).ThenByDescending(x=>x.Rating);
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return actors.Values.Where(x => x.Movies.Count==0);
        }
    }
}
