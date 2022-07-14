using GameFinder.Services.GameConsoleService;
using Microsoft.AspNetCore.Mvc;
using GameFinder.Data;
using GameFinder.Data.Models;

namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameConsoleController : ControllerBase
    {
        private readonly IGameConsoleService _service;
        private readonly AppDbContext _dbContext;

        public GameConsoleController(IGameConsoleService service, AppDbContext dbContext) {
            _service = service;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameConsoleAsync([FromBody] GameConsole model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var createGameConsole = await _service.CreateGameConsoleAsync(model);
            if (createGameConsole) {
                return Ok("Game Console was created.");
            }
            return BadRequest("Game Console could not be created, sorry.");
        }

        [HttpGet]
        public async Task<IEnumerable<GameConsole>> GetAllGameConsoleAsync() {
            var gameConsoles = await _service.GetAllGameConsolesAsync();

            return gameConsoles;
        }

        [HttpPut("{consoleId:int}")]
        public async Task<IActionResult> PatchGameConsoleAsync([FromRoute] int id) {
            var requestConsole = await _dbContext.GameConsoles.FindAsync(id);
            var updatedGameConsole = await _service.UpdateGameConsoleAsync(requestConsole);
            if (updatedGameConsole is false) {
                return NotFound();
            }
            return Ok(updatedGameConsole);
        }

        [HttpDelete("{consoleId:int}")]
        public async Task<IActionResult> DeleteGameConsoleAsync(int Id) {
            var gameConsoleToDelete = await _service.DeleteGameConsoleAsync(Id);
            if (gameConsoleToDelete is false) {
                return NotFound();
            }
            return Ok(gameConsoleToDelete);
        }

    }
}