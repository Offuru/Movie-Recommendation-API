using Database.Dtos.Request;
using Database.Dtos.Response;
using Database.Entities;
using System.Dynamic;
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


        public static GetMovieDetailsResponse ToMovieDto(this Movie entity)
        {
            if (entity == null)
            {
                return null;
            }

            var result = new GetMovieDetailsResponse();

            result.Name = entity.Name;
            result.Duration = entity.Duration.ToString();
            result.Genres = entity.Genres;
            result.Rating = entity.Rating;  
            result.UserRating = entity.UserRating;
            result.CriticRating = entity.CriticRating;
            result.ReviewsIds = entity.Reviews?.Select(r => r.Id).ToList() ?? new List<int>();

            return result;
        }

        public static List<GetMovieDetailsResponse> ToMoviesDto(this List<Movie> movies)
        {
            var result = movies.Select(m => m.ToMovieDto()).ToList();

            return result;
        }
    }
}
