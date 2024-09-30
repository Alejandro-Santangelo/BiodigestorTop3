using System.Collections.Generic;

namespace Biodigestor.Models
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; } = string.Empty; // Inicializado con un valor predeterminado

        // Inicializado como una lista vacía para evitar errores de referencia nula
        public List<RoleSelectionViewModel> Roles { get; set; } = new List<RoleSelectionViewModel>(); 
    }

    public class RoleSelectionViewModel
    {
        public string RoleName { get; set; } = string.Empty; // Inicializado para evitar errores de referencia nula
        public bool IsSelected { get; set; } = false; // Inicializado con un valor predeterminado
    }
}

