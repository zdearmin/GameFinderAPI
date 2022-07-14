using Microsoft.AspNetCore.Mvc;

namespace GameFinder.WebAPI.Controllers
{
    public class GenreController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenreAsync() {
            throw new NotImplementedException();
        }

        // TODO Finish Patch to update Genre
        [HttpPatch]
        public async Task<IActionResult> UpdateGenreAsync() {
        }

        // TODO Finish Delete to Delete Genre
        [HttpDelete]
        public async Task<IActionResult> DeleteGenreAsync() {
        }
        
    }
}