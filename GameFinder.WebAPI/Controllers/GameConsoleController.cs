using GameFinder.Services.GameConsoleService;
using Microsoft.AspNetCore.Mvc;
using GameFinder.Data;

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
        // [HttpPost]
        // public async Task<IActionResult> CreateGameConsoleAsync() {
        //     throw new NotImplementedException();
        // }

        // [HttpGet]
        // public async Task<IActionResult> GetAllGameConsoleAsync() {
        //     throw new NotImplementedException();
        // }

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