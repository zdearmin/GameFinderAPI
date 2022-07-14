using Microsoft.AspNetCore.Mvc;

namespace GameFinder.WebAPI.Controllers
{
    public class GameConsoleController : ControllerBase
    {
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
        public async Task<IActionResult> UpdateGameConsoleAsync() {
        }

        // TODO Finish Delete to Delete Console
        [HttpDelete]
        public async Task<IActionResult> DeleteGameConsoleAsync() {
        }

    }
}