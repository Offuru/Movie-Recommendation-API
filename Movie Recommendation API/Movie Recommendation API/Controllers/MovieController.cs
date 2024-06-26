using Microsoft.AspNetCore.Mvc;
using API.Controllers;
using Core.Services;
using Database.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Exceptions;

namespace Movie_Recommendation_API.Controllers
{
    [Route("api/movies")]
    public class MovieController : BaseController
    {
        private MovieService MovieService { get; set; }

        public MovieController(MovieService movieService)
        {
            MovieService = movieService;
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovie([FromBody] AddMovieRequest payload)
        {
            MovieService.AddMovie(payload);
            return Ok("Movie has been added succesfully");
        }

        [HttpGet]
        [Route("{movieId}/get-details")]
        public IActionResult GetMovieDetails([FromRoute] int movieId)
        {
            var result = MovieService.GetMovieDetailsById(movieId);
            return Ok(result);
        }

        [HttpGet]
        [Route("/get-movies")]
        public IActionResult GetMovies([FromQuery]GetMoviesRequest payload)
        {
            var result = MovieService.GetMovies(payload);
            return Ok(result);
        }

        [HttpPut]
        [Route("{movieId}/edit")]
        public IActionResult EditMovieDetails([FromRoute] int movieId, [FromBody] EditMovieRequest payload)
        {
            MovieService.EditMovie(movieId, payload);
            return Ok("Movie has been succesfully edited");
        }

        [HttpDelete]
        [Route("delete-movie")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMovie([FromQuery] int movieId)
        {
            MovieService.DeleteMovie(movieId);
            return Ok("Movie has been deleted succesfully");
        }
    }
}
