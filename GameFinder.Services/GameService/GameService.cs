using GameFinder.Data;
using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFinder.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _dbContext;
        public GameService (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> CreateGameAsync (Game request)
        {
            var gameEntity = new Game
            {
                Title = request.Title,
                GenreId = request.GenreId,
                Genre = request.Genre,
                GameConsoleId = request.GameConsoleId,
                GameConsole = request.GameConsole
            };

            _dbContext.Games.Add(gameEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            var games = await _dbContext.Games

            .ToListAsync();

            return games;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> UpdateGameAsync(Game request)
        {
            var gameEntity = await _dbContext.Games.FindAsync(request.Id);

            gameEntity.Title = request.Title;
            gameEntity.Genre = request.Genre;
            gameEntity.GameConsole = request.GameConsole;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> DeleteGameAsync(int id)
        {
            var gameEntity = await _dbContext.Games.FindAsync(id);

            _dbContext.Games.Remove(gameEntity);

            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}