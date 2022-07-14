using GameFinder.Data;
using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFinder.Services.GameConsoleService
{
    public class GameConsoleService : IGameConsoleService
    {
        private readonly AppDbContext _dbContext;
        public GameConsoleService (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> CreateGameConsoleAsync(GameConsole request)
        {
            var gameConsoleEntity = new GameConsole
            {
                Id = request.Id,
                Title = request.Title
            };

            _dbContext.GameConsoles.Add(gameConsoleEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<GameConsole>> GetAllGameConsolesAsync()
        {
            var gameConsoles = await _dbContext.GameConsoles

            .ToListAsync();

            return gameConsoles;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> UpdateGameConsoleAsync(GameConsole request)
        {
            var gameConsoleEntity = await _dbContext.GameConsoles.FindAsync(request.Id);

            gameConsoleEntity.Title = request.Title;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> DeleteGameConsoleAsync(int id)
        {
            var gameConsoleEntity = await _dbContext.GameConsoles.FindAsync(id);

            _dbContext.GameConsoles.Remove(gameConsoleEntity);

            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}