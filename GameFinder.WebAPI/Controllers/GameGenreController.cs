using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> UpdateGameGenreAsync() {
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteGameGenreAsync(int Id) {
            var gameGenreToDelete = await _service.GetGameGenreByIdAsync(Id);
            if (gameGenreToDelete is null) {
                return NotFound();
            }
            return Ok(gameGenreToDelete);
        }
        
    }
}