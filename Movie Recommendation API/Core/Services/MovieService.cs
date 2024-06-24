using Core.Mapping;
using Database.Dtos.Request;
using Database.Repositories;

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
            MovieRepository.AddMovie(movie);
        }
        
        public void DeleteMovie(int movieId)
        {
            var movie = MovieRepository.GetMovieById(movieId);

            MovieRepository.DeleteMovie(movie);
        }
    }
}
