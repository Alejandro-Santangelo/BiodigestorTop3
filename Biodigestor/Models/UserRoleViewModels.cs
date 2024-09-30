using Microsoft.AspNetCore.Mvc; // Para usar Controller y IActionResult
using Biodigestor.Models; // Asegúrate de tener esta línea para UserRoleViewModel
using System.Collections.Generic; // Necesario para List<T>


namespace Biodigestor.Models
{ 
public class UserRoleViewModel
{
    public string UserId { get; set; }
    public string RoleName { get; set; }
    public List<string> Roles { get; set; }

    // Constructor para asegurar que las propiedades son inicializadas
    public UserRoleViewModel(string userId, string roleName, List<string> roles)
    {
        UserId = userId;
        RoleName = roleName;
        Roles = roles ?? new List<string>(); // Inicializa roles como una lista vacía si es nulo
    }
}
}

