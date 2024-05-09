using Blog.Dtos;
using Blog.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        public IActionResult Register(UserDto user)
        {
            var newUser = _userService.Add(user);
            if (newUser == null)
            {
                return BadRequest("Failed to register user.");
            }
            return Ok(newUser);
        }

        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            var loggedInUser = _userService.Login(login, password);
            if (loggedInUser == null)
            {
                return BadRequest("Invalid username or password.");
            }
            return Ok(loggedInUser);
        }
    }
}
