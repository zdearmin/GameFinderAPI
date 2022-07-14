using GameFinder.Data;
using GameFinder.Data.Models;

namespace GameFinder.Services.GameService
{
    public interface IGameService
    {
        Task<bool> CreateGameAsync(Game request);
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<bool> UpdateGameAsync(Game request);
        Task<bool> DeleteGameAsync(int id);
    }
}