using GameFinder.Services.GameService;
using Microsoft.AspNetCore.Mvc;
using GameFinder.Data;
using GameFinder.Data.Models;

namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {

        private readonly IGameService _service;
        private readonly AppDbContext _dbContext;

        public GameController(IGameService service, AppDbContext dbContext) {
            _service = service;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync([FromBody] Game model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var createGame = await _service.CreateGameAsync(model);
            if (createGame) {
                return Ok("Game was created.");
            }
            return BadRequest("Game could not be created, sorry.");
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> GetAllGameAsync() {
            var games = await _service.GetAllGamesAsync();

            return games;
        }

        [HttpPut("{gameId:int}")]
        public async Task<IActionResult> PatchGameAsync([FromRoute] int id) {
            var requestGame = await _dbContext.Games.FindAsync(id);
            var updatedGame = await _service.UpdateGameAsync(requestGame);
            if (updatedGame is false) {
                return NotFound();
            }
            return Ok(updatedGame);
        }

        [HttpDelete("{gameId:int}")]
        public async Task<IActionResult> DeleteGameAsync(int Id) {
            var gameToDelete = await _service.DeleteGameAsync(Id);
            if (gameToDelete is false) {
                return NotFound();
            }
            return Ok(gameToDelete);
        }

        
    }
}