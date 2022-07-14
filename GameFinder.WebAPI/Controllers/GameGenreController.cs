using Microsoft.AspNetCore.Mvc;
using GameFinder.Services.GameGenreService;

namespace GameFinder.WebAPI.Controllers
{
    public class GameGenreController : ControllerBase
    {

        private readonly IGameGenreService _service;
        
        public GameGenreController(IGameGenreService service) {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameGenreAsync() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGameGenreAsync() {
            throw new NotImplementedException();
        }

        // TODO Finish Patch to update GameGenre
        [HttpPatch]
        public async Task<IActionResult> PatchGameGenre([FromRoute] int Id, [FromBody] JsonPatchDocument gameGenreDocument) {
            var updatedGameGenre = await _service.UpdateGenreAsync(Id, gameGenreDocument);
            if (updatedGameGenre is null) {
                return NotFound();
            }
            return Ok(updatedGameGenre);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteGameGenreAsync(int Id) {
            var gameGenreToDelete = await _service.GetAllGenresAsync();
            if (gameGenreToDelete is null) {
                return NotFound();
            }
            return Ok(gameGenreToDelete);
        }
        
    }
}