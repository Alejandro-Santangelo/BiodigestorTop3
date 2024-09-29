using System.ComponentModel.DataAnnotations;

namespace Biodigestor.DTOs
{
    public class RegisterDto
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string ConfirmPassword { get; set; } // Agregada propiedad ConfirmPassword

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Rol { get; set; }

        [Required]
        public required string Nombre { get; set; }

        [Required]
        public required string Apellido { get; set; }

        [Required]
        public required int DNI { get; set; }
    }
}

