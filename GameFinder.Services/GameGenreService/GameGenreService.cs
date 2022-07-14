using GameFinder.Data;
using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFinder.Services.GameGenreService
{
    public class GameGenreService : IGameGenreService
    {
        private readonly AppDbContext _dbContext;
        public GameGenreService (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> CreateGenreAsync(GameGenre request)
        {
            var genreEntity = new GameGenre
            {
                Title = request.Title
            };

            _dbContext.GameGenres.Add(genreEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<GameGenre>> GetAllGenresAsync()
        {
            var genres = await _dbContext.GameGenres

            .ToListAsync();

            return genres;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> UpdateGenreAsync(GameGenre request)
        {
            var genreEntity = await _dbContext.GameGenres.FindAsync(request.Id);

            genreEntity.Title = request.Title;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        // TODO Add authorization for admins only for this method
        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genreEntity = await _dbContext.GameGenres.FindAsync(id);

            _dbContext.GameGenres.Remove(genreEntity);

            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}