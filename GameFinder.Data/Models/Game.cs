using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameFinder.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public GameGenre Genre { get; set; }

        [ForeignKey(nameof(GameConsole))]
        public int GameConsoleId { get; set; }
        public GameConsole GameConsole { get; set; }
    }
}