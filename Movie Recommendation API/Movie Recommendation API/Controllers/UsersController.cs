using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Database.Dtos.Request;


namespace Movie_Recommendation_API.Controllers
{
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private UsersService UsersService { get; set; }

        public UsersController(UsersService usersService)
        {
            UsersService = usersService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] AddUserRequest payload)
        {
            return Ok("User has been succesfully created");
        }

        [HttpGet]
        [Route("{userId}/get-details")]
        public IActionResult GetUserDetails([FromRoute] int userId)
        {
            return Ok();
        }
    }
}
