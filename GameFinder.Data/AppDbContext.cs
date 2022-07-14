using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFinder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameConsole> GameConsoles { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<User> Users { get; set; }
    }
}