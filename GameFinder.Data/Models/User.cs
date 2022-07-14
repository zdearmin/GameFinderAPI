using System.ComponentModel.DataAnnotations;

namespace GameFinder.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "{0} must be longer than {1} characters.")]
        public string Username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "{0} must be longer than {1} characters.")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}