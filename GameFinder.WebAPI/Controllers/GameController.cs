using GameFinder.Services.GameService;
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
        public async Task<IActionResult> PatchGame([FromRoute] int Id, [FromBody] JsonPatchDocument gameDocument) {
            var updatedGame = await _service.UpdateGameAsync(Id, gameDocument);
            if (updatedGame is null) {
                return NotFound();
            }
            return Ok(updatedGame);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGameAsync(int Id) {
            var gameToDelete = await _service.DeleteGameAsync(Id);
            if (gameToDelete is false) {
                return NotFound();
            }
            return Ok(gameToDelete);
        }

        
    }
}