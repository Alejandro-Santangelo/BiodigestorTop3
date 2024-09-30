using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Biodigestor.Models; // Asegúrate de que esta ruta sea correcta
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [ApiController] // Agregado para que Swagger reconozca este controlador como un controlador de API
    [Route("api/[controller]")] // Define la ruta base para el controlador
    public class UserRoleController : ControllerBase // Cambiado a ControllerBase para API
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Listar Usuarios
        [HttpGet] // Agregado para definir el método como un GET
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return Ok(users); // Cambiado a Ok para devolver la lista de usuarios
        }

        // Asignar Roles
        [HttpGet("manage/{userId}")] // Cambiado para incluir el parámetro userId en la ruta
        public async Task<IActionResult> Manage(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var roles = await _roleManager.Roles.ToListAsync(); // Cargar roles asíncronamente
            var userRoles = await _userManager.GetRolesAsync(user) ?? new List<string>(); // Asegúrate de que no sea nulo

            var model = new ManageUserRolesViewModel
            {
                UserId = user.Id,
                Roles = roles.Select(r => new RoleSelectionViewModel
                {
                    RoleName = r.Name,
                    IsSelected = userRoles.Contains(r.Name) // Puede dar advertencia, manejémosla
                }).ToList()
            };

            return Ok(model); // Cambiado a Ok para devolver el modelo
        }

        // Asignar Roles
        [HttpPost("manage")] // Cambiado para definir la ruta del POST
        public async Task<IActionResult> Manage(ManageUserRolesViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserId))
            {
                return BadRequest("El usuario debe tener un rol asignado.");
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return NotFound();

            var roles = await _userManager.GetRolesAsync(user) ?? new List<string>(); // Asegúrate de que no sea nulo

            if (roles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, roles);
            }

            var selectedRoles = model.Roles?
                .Where(r => r.IsSelected)
                .Select(r => r.RoleName)
                .Where(roleName => !string.IsNullOrEmpty(roleName)) // Filtra nombres nulos o vacíos
                .ToList() ?? new List<string>(); // Asegúrate de que no sea nulo

            if (selectedRoles.Any())
            {
                await _userManager.AddToRolesAsync(user, selectedRoles);
            }

            return RedirectToAction("Index");
        }
    }
}



