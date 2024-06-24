using Database.Context;
using Database.Entities;

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
    }
}
