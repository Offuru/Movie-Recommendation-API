using Database.Dtos.Request;
using Database.Entities;
using System.Runtime.CompilerServices;

namespace Core.Mapping
{
    public static class MovieMappingExtension
    {
        public static Movie ToEntity(this AddMovieRequest payload)
        {
            if (payload == null)
            {
                return null;
            }

            var movie = new Movie();

            movie.Name = payload.Name;
            movie.Duration = TimeSpan.Parse(payload.Duration);
            movie.Genres = payload.Genres;
            movie.Rating = 0;
            movie.UserRating = 0;
            movie.CriticRating = 0;
            movie.Reviews = new List<Review>();
            movie.DateCreated = DateTime.UtcNow;
            movie.DateUpdated = DateTime.UtcNow;

            return movie;
        }
    }
}
