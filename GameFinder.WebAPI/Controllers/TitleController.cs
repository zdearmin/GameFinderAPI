using Microsoft.AspNetCore.Mvc;

namespace GameFinder.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class TitleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTitleAsync() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTitleAsync() {
            throw new NotImplementedException();
        }

        // TODO Finish Patch to update Title
        [HttpPatch]
        public async Task<IActionResult> UpdateTitleAsync() {
        }

        // TODO Finish Delete to Delete Title
        [HttpDelete]
        public async Task<IActionResult> DeleteTitleAsync() {
        }

        
    }
}