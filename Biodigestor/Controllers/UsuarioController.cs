using Biodigestor.Data;
using Biodigestor.Model;
using Biodigestor.DTOs; // Asegúrate de importar tu espacio de nombres donde están los DTOs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization; // Asegúrate de importar este espacio de nombres
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biodigestor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly BiodigestorContext _context;
        private readonly UserManager<Usuario> _userManager; // Cambiado a Usuario
        private readonly SignInManager<Usuario> _signInManager; // Cambiado a Usuario

        public UsuariosController(BiodigestorContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
public async Task<ActionResult<Usuario>> ObtenerUsuario(int id)
{
    var usuario = await _context.Usuarios.FindAsync(id);
    
    if (usuario == null)
    {
        return NotFound("Usuario no encontrado");
    }
    
    return Ok(usuario);
}


        [HttpPost("admin/agregar_usuario")]
public async Task<IActionResult> AgregarUsuario([FromBody] RegisterDto registerDto)
{
    if (!new[] { "Cliente", "Administracion", "Tecnico" }.Contains(registerDto.Rol))
    {
        return BadRequest("Rol no válido");
    }

    var usuario = new Usuario 
    { 
        Nombre = registerDto.Nombre,
        Apellido = registerDto.Apellido,
        DNI = registerDto.DNI,
        Rol = registerDto.Rol, // Asegúrate de que esta línea esté aquí
        UserName = registerDto.Username, 
        Email = registerDto.Email 
    };

    var result = await _userManager.CreateAsync(usuario, registerDto.Password);

    if (!result.Succeeded)
    {
        return BadRequest(result.Errors.Select(e => e.Description)); // Agrega una descripción de los errores
    }

    await _userManager.AddToRoleAsync(usuario, registerDto.Rol);

    return CreatedAtAction(nameof(ObtenerUsuario), new { id = usuario.Id }, usuario);
}


        [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
{
    var usuario = await _userManager.FindByNameAsync(loginDto.Username);
    if (usuario == null)
    {
        return Unauthorized("El usuario no existe");
    }

    var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
    
    if (result.Succeeded)
    {
        return Ok("Login exitoso");
    }

    if (result.IsLockedOut)
    {
        return Unauthorized("La cuenta está bloqueada");
    }

    return Unauthorized("Credenciales incorrectas");
}


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, Usuario usuarioActualizado)
        {
            if (id != usuarioActualizado.Id)
            {
                return BadRequest("El ID del usuario no coincide");
            }

            _context.Entry(usuarioActualizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound("Usuario no encontrado");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}







