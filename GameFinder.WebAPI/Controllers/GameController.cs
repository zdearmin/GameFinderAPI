using GameFinder.Services.GameService;
using Microsoft.AspNetCore.Mvc;
using GameFinder.Data;

namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class GameController : ControllerBase
    {

        private readonly IGameService _service;
        private readonly AppDbContext _dbContext;

        public GameController(IGameService service, AppDbContext dbContext) {
            _service = service;
            _dbContext = dbContext;
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateGameAsync() {
        //     throw new NotImplementedException();
        // }

        // [HttpGet]
        // public async Task<IActionResult> GetAllGameAsync() {
        //     throw new NotImplementedException();
        // }

        [HttpPut("{gameId:int}")]
        public async Task<IActionResult> PatchGameAsync([FromRoute] int id) {
            var requestGame = await _dbContext.Games.FindAsync(id);
            var updatedGame = await _service.UpdateGameAsync(requestGame);
            if (updatedGame is false) {
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