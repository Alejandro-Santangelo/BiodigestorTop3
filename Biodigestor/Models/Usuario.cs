using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Biodigestor.Model // Asegúrate de que este namespace coincida con tu estructura de carpetas
{
    public class Usuario : IdentityUser<int>
    {
        [Key] // Indica que este campo es la clave primaria
        public override int Id { get; set; } // PK e Identity

        [Required]
        public string Nombre { get; set; } = string.Empty; // Inicializar en string.Empty

        [Required]
        public string Apellido { get; set; } = string.Empty; // Inicializar en string.Empty

        [Required]
        public int DNI { get; set; }

        [Required]
        public string Rol { get; set; } = string.Empty; // Inicializar en string.Empty

        [Required] // Agregado para el nombre de usuario
        public new string UserName { get; set; } = string.Empty; // Inicializar en string.Empty

        [Required] // Agregado para el email
        public new string Email { get; set; } = string.Empty; // Inicializar en string.Empty
    }
}



