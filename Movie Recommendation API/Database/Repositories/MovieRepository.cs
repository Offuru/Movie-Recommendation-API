using Database.Context;
using Database.Dtos.Request;
using Database.Entities;
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

            return result;
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
