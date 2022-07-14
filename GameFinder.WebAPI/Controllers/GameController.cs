using Microsoft.AspNetCore.Mvc;

namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class GameController : ControllerBase
    {

        private readonly IGameService _service;
        
        public GameController(IGameService service) {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGameAsync() {
            throw new NotImplementedException();
        }

        // TODO Finish Patch to update Game
        [HttpPatch]
        public async Task<IActionResult> UpdateGameAsync() {
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGameAsync(int Id) {
            var gameToDelete = await _service.GetGameByIdAsync(Id);
            if (gameToDelete is null) {
                return NotFound();
            }
            return Ok(gameToDelete);
        }

        
    }
}