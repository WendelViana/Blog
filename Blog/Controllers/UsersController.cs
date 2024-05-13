using Blog.Entities;
using Blog.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register([FromBody]UserEntity user)
        {
            var newUser = _userService.Add(user);
            if (!newUser)
            {
                return BadRequest("Failed to register user.");
            }
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult Login(string login, string password)
        {
            var loggedInUser = _userService.Login(login, password);
            if (loggedInUser == null)
            {
                return BadRequest("Invalid username or password.");
            }

            return Ok(loggedInUser);
        }

        [HttpGet("list")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            if (users == null)
            {
                return NoContent();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult DeleteUser(int id)
        {
            var deleted = _userService.Delete(id);
            if (!deleted)
            {
                return BadRequest("Failed to delete user.");
            }
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateUser(int id, [FromBody] UserEntity user)
        {
            user.Id = id;
            var updated = _userService.Update(user);
            if (!updated)
            {
                return BadRequest("Failed to update user.");
            }
            return Ok();
        }
    }
}
