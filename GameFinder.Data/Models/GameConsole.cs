using System.ComponentModel.DataAnnotations;

namespace GameFinder.Data.Models
{
    public class GameConsole
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}