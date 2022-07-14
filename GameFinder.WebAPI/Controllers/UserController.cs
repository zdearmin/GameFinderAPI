// TODO Add/Update using statements
using Microsoft.AspNetCore.Mvc;
using GameFinder.Services.User;
using GameFinder.Data.Models;
//using GameFinder.Data.Models.User;


namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // TODO Check User Service for correct name once created
        private readonly IUserService _service;
        
        public UserController(IUserService service) {
            _service = service;
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

        // TODO Finish Patch to update User 
        [HttpPatch("{userId:int}")]
        public async Task<IActionResult> PatchUser([FromRoute] int userId, [FromBody] JsonPatchDocument userDocument) {
            var updatedUser = await _service.UpdateUserPatchAsync(userId, userDocument);
            if (updatedUser is null) {
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