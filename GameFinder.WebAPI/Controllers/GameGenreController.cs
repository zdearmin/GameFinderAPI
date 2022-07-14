using Microsoft.AspNetCore.Mvc;
using GameFinder.Services.GameGenreService;
using GameFinder.Data;

namespace GameFinder.WebAPI.Controllers
{
    public class GameGenreController : ControllerBase
    {

        private readonly IGameGenreService _service;
        private readonly AppDbContext _dbContext;

        public GameGenreController(IGameGenreService service, AppDbContext dbContext) {
            _service = service;
            _dbContext = dbContext;
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateGameGenreAsync() {
        //     throw new NotImplementedException();
        // }

        // [HttpGet]
        // public async Task<IActionResult> GetAllGameGenreAsync() {
        //     throw new NotImplementedException();
        // }

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