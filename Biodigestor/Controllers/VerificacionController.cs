using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Biodigestor.Data;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificacionController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public VerificacionController(BiodigestorContext context)
        {
            _context = context;
        }

        // GET: api/verificar-dni?dni=12345678
        [HttpGet("verificar-dni")]
        public IActionResult VerificarDNI([FromQuery] int dni)
        {
            // Verificar si el DNI existe en la tabla Clientes
            var cliente = _context.Clientes.FirstOrDefault(c => c.DNI == dni);
            // Verificar si el DNI existe en la tabla Personal
            var personal = _context.Personal.FirstOrDefault(p => p.DNI == dni);

            if (cliente != null || personal != null)
            {
                return Ok(new { existe = true });
            }
            else
            {
                return Ok(new { existe = false });
            }
        }
    }
}
