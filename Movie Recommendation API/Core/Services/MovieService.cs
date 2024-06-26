using Core.Mapping;
using Database.Dtos.Request;
using Database.Dtos.Response;
using Database.Repositories;
using Infrastructure.Exceptions;

namespace Core.Services
{
    public class MovieService
    {
        MovieRepository MovieRepository { get; set; }

        public MovieService(MovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        public void AddMovie(AddMovieRequest payload)
        {
            var movie = payload.ToEntity();
            movie.Genres = movie.Genres.Select(g => g.ToLower()).ToList();

            MovieRepository.AddMovie(movie);
        }

        public void DeleteMovie(int movieId)
        {
            var movie = MovieRepository.GetMovieById(movieId);

            MovieRepository.DeleteMovie(movie);
        }

        public GetMovieDetailsResponse GetMovieDetailsById(int movieId)
        {
            var movie = MovieRepository.GetMovieById(movieId);
            var result = movie.ToMovieDto();

            return result;
        }

        public void EditMovie(int movieId, EditMovieRequest payload)
        {
            var movie = MovieRepository.GetMovieById(movieId);
            movie.Genres = movie.Genres.Select(g => g.ToLower()).ToList();

            MovieRepository.EditMovie(movie, payload);
        }
    }
}
