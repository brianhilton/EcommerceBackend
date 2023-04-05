using Ecommerce.Logic.Interfaces;
using Ecommerce.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _users;
        private readonly ILogger _log;
        public UserController(IUserService users, ILoggerFactory loggerFactory)
        {
            _users = users;
            _log = loggerFactory.CreateLogger<UserController>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByID(string id)
        {
            var user = await _users.GetUserByIDAsync(id);

            if (user == null) { return NotFound(); }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (user == null) { return BadRequest(); }

            var newUser = await _users.CreateUserAsync(user);

            return Ok(newUser);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _users.GetUserByIDAsync(id);

            if (user == null) { return NotFound(); }

            await _users.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
