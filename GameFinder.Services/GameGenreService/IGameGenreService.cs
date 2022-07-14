using GameFinder.Data;
using GameFinder.Data.Models;

namespace GameFinder.Services.GameGenreService
{
    public interface IGameGenreService
    {
        Task<bool> CreateGenreAsync(GameGenre request);
        Task<IEnumerable<GameGenre>> GetAllGenresAsync();
        Task<bool> UpdateGenreAsync(GameGenre request);
        Task<bool> DeleteGenreAsync(int id);
    }
}