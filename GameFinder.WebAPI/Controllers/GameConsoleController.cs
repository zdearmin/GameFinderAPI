using Microsoft.AspNetCore.Mvc;

namespace GameFinder.WebAPI.Controllers
{
    public class GameConsoleController : ControllerBase
    {
        private readonly IGameConsoleService _service;
        
        public GameConsoleController(IGameConsoleService service) {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGameConsoleAsync() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGameConsoleAsync() {
            throw new NotImplementedException();
        }

        // TODO Finish Patch to update Console
        [HttpPatch]
        public async Task<IActionResult> PatchGameConsole([FromRoute] int Id, [FromBody] JsonPatchDocument gameConsoleDocument) {
            var updatedGameConsole = await _service.UpdateGameConsolePatchAsync(Id, gameConsoleDocument);
            if (updatedGameConsole is null) {
                return NotFound();
            }
            return Ok(updatedGameConsole);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGameConsoleAsync(int Id) {
            var gameConsoleToDelete = await _service.GetGameConsoleByIdAsync(Id);
            if (gameConsoleToDelete is null) {
                return NotFound();
            }
            return Ok(gameConsoleToDelete);
        }

    }
}