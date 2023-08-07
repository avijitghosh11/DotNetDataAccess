using DotNetCore.Dapper.API.Models;
using DotNetCore.Dapper.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Dapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with id {id} is not found.");
            }
            return user;
        }

        [HttpGet("GetUsersByLastName/{lastName}")]
        public ActionResult<List<User>> GetUsersByLastName(string lastName)
        {
            var users = _userService.GetUsersByLastName(lastName);
            if (users.Count == 0)
            {
                return NotFound($"User with last name {lastName} is not found.");
            }
            return users;
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _userService.InsertUser(user);
            return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {

            if (_userService.GetUserById(id) == null)
            {
                return NotFound($"User with id {id} is not found.");
            }
            _userService.UpdateUser(id, user);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_userService.GetUserById(id) == null)
            {
                return NotFound($"User with id {id} is not found.");
            }
            _userService.DeleteUser(id);

            return Ok($"User with id {id} is deleted.");
        }
    }
}
