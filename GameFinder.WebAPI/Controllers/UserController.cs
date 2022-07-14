// TODO Add/Update using statements
using Microsoft.AspNetCore.Mvc;
using GameFinder.Services.UserService;
using GameFinder.Data.Models;
using GameFinder.Data;
//using GameFinder.Data.Models.User;


namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // TODO Check User Service for correct name once created
        private readonly IUserService _service;
        private readonly AppDbContext _dbContext;

        public UserController(IUserService service, AppDbContext dbContext) {
            _service = service;
            _dbContext = dbContext;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var registerResult = await _service.RegisterUserAsync(model);
            if (registerResult) {
                return Ok("User was registered.");
            }
            return BadRequest("User could not be registered.");
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int userId) {
            var userDetail = await _service.GetUserByIdAsync(userId);
            if (userDetail is null) {
                return NotFound();
            }
            return Ok(userDetail);
        }

        // TODO Finish Put to update User 
        [HttpPut("{userId:int}")]
        public async Task<IActionResult> PatchUser([FromRoute] int id)
        // [FromBody] JsonPatchDocument userDocument
        {
            var requestUser = await _dbContext.Users.FindAsync(id);
            var updatedUser = await _service.UpdateUserAsync(requestUser);
            if (updatedUser is false) {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteUserAsync(int userId) {
            var userToDelete = await _service.GetUserByIdAsync(userId);
            if (userToDelete is null) {
                return NotFound();
            }
            return Ok(userToDelete);
        }
    }
}