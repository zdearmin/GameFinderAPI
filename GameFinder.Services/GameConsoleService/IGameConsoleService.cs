using GameFinder.Data;
using GameFinder.Data.Models;

namespace GameFinder.Services.GameConsoleService
{
    public interface IGameConsoleService
    {
        Task<bool> CreateGameConsoleAsync(GameConsole request);
        Task<IEnumerable<GameConsole>> GetAllGameConsolesAsync();
        Task<bool> UpdateGameConsoleAsync(GameConsole request);
        Task<bool> DeleteGameConsoleAsync(int id);
    }
}