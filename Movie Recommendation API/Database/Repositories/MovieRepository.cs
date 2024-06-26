using Database.Context;
using Database.Dtos.Request;
using Database.Entities;
using Database.QueryExtensions;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MovieRepository : BaseRepository
    {
        public MovieRepository(MovieRecommendationDbContext dbContext) : base(dbContext) { }

        public void AddMovie(Movie movie)
        {
            dbContext.Add(movie);
            SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            movie.DateDeleted = DateTime.UtcNow;
            SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            var result = dbContext.Movies
                .Where(m => m.Id == id)
                .Where(m => m.DateDeleted == null)
                .FirstOrDefault();

            if (result == null)
            {
                throw new ResourceMissingException($"Movie with id {id} does not exist");
            }

            return result;
        }

        public List<Movie> GetAllMovies(GetMoviesRequest payload)
        {
            var results = GetMoviesQuery(payload)
                .Sort(payload.SortingCriterion)
                .AsNoTracking()
                .ToList();
                

            return results;
        }

        public int CountMovies(GetMoviesRequest payload)
        {
            var count = GetMoviesQuery(payload).Count();

            return count;
        }

        private IQueryable<Movie> GetMoviesQuery(GetMoviesRequest payload)
        {
            var query = dbContext.Movies
                .Where(m => m.DateDeleted == null)
                .WhereName(payload)
                .WhereRating(payload);

            return query;
        }

        public void EditMovie(Movie movie, EditMovieRequest payload)
        {
            movie.Name = payload.Name;
            movie.Duration = TimeSpan.Parse(payload.Duration);
            movie.Genres = payload.Genres;

            if (dbContext.Entry(movie).State == EntityState.Modified)
            {
                movie.DateUpdated = DateTime.UtcNow;
            }

            SaveChanges();
        }
    }
}
