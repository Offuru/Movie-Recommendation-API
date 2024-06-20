using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Database.Dtos.Request;


namespace API.Controllers
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
        public IActionResult Register([FromBody] RegisterUserRequest payload)
        {
            UsersService.Register(payload);
            return Ok("User has been succesfully created");
        }

        [HttpGet]
        [Route("{userId}/get-details")]
        public IActionResult GetUserDetails([FromRoute] int userId)
        {
            var result = UsersService.GetUserDetailsById(userId);
            return Ok(result);
        }
    }
}
