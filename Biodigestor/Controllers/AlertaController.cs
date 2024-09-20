using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biodigestor.Models;
using Biodigestor.Data;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public AlertaController(BiodigestorContext context)
        {
            _context = context;
        }

        // POST alerta
        [HttpPost]
        public async Task<ActionResult<Alerta>> PostAlerta(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlerta), new { id = alerta.IdAlerta }, alerta);
        }

        // GET alertas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAlertas()
        {
            return await _context.Alertas.ToListAsync();
        }

        // GET alerta/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetAlerta(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);

            if (alerta == null)
            {
                return NotFound();
            }

            return alerta;
        }

        // GET alerta/fecha/{fecha}
        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAlertaByFecha(DateTime fecha)
        {
            return await _context.Alertas.Where(a => a.FechaHora.Date == fecha.Date).ToListAsync();
        }
    }
}