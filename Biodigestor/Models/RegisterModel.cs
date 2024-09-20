using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class RegisterModel
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string ConfirmPassword { get; set; }

        public required string Email { get; set; }
    }
}


