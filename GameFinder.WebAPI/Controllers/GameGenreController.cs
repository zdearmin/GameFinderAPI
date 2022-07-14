using Microsoft.AspNetCore.Mvc;
using GameFinder.Services.GameGenreService;
using GameFinder.Data;
using GameFinder.Data.Models;

namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameGenreController : ControllerBase
    {

        private readonly IGameGenreService _service;
        private readonly AppDbContext _dbContext;

        public GameGenreController(IGameGenreService service, AppDbContext dbContext) {
            _service = service;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameGenreAsync([FromBody] GameGenre model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var createGenre = await _service.CreateGenreAsync(model);
            if (createGenre) {
                return Ok("Genre was created.");
            }
            return BadRequest("Genre could not be created, sorry.");
        }

        [HttpGet]
        public async Task<IEnumerable<GameGenre>> GetAllGameGenreAsync() {
            var gameGenres = await _service.GetAllGenresAsync();

            return gameGenres;
        }

        [HttpPut("{gameGenreId:int}")]
        public async Task<IActionResult> PatchGameGenreAsync([FromRoute] int id) {
            var requestGameGenre = await _dbContext.GameGenres.FindAsync(id);
            var updatedGameGenre = await _service.UpdateGenreAsync(requestGameGenre);
            if (updatedGameGenre is false) {
                return NotFound();
            }
            return Ok(updatedGameGenre);
        }

        [HttpDelete("{gameGenreId:int}")]
        public async Task<IActionResult> DeleteGameGenreAsync(int Id) {
            var gameGenreToDelete = await _service.GetAllGenresAsync();
            if (gameGenreToDelete is null) {
                return NotFound();
            }
            return Ok(gameGenreToDelete);
        }
        
    }
}