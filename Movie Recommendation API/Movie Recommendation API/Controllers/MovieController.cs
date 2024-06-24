using Microsoft.AspNetCore.Mvc;
using API.Controllers;
using Core.Services;
using Database.Dtos.Request;

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
        public IActionResult AddMovie([FromBody] AddMovieRequest payload)
        {
            MovieService.AddMovie(payload);
            return Ok("Movie has been added succesfully");
        }

        [HttpDelete]
        [Route("delete-movie")]
        public IActionResult DeleteMovie([FromQuery] int movieId)
        {
            MovieService.DeleteMovie(movieId);
            return Ok("Movie has been deleted succesfully");
        }
    }
}
