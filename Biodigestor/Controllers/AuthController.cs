using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Biodigestor.Models;
using Biodigestor.Controllers.Services;

namespace Biodigestor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.ConfirmPassword))
            {
                return BadRequest("Se requieren nombre de usuario, contraseña y confirmación de contraseña.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Las contraseñas no coinciden.");
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email // Asumiendo que Email es opcional en RegisterModel
            };

            try
            {
                await _userService.CreateUser(user, model.Password);
                return Ok("Usuario registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Se requieren nombre de usuario y contraseña.");
            }

            var user = await _userService.AuthenticateUser(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized("Nombre de usuario o contraseña no válidos.");
            }

            return Ok("Inicio de sesión exitoso.");
        }
    }
}













