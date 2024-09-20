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
    public class AlarmaController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public AlarmaController(BiodigestorContext context)
        {
            _context = context;   
        }

        // POST alarma
        [HttpPost]
        public async Task<ActionResult<Alarma>> PostAlarma(Alarma alarma)
        {
            _context.Alarmas.Add(alarma);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlarma), new { id = alarma.IdAlarma }, alarma);
        }

        // GET alarmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alarma>>> GetAlarmas()
        {
            return await _context.Alarmas.ToListAsync();
        }

        // GET alarma/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Alarma>> GetAlarma(int id)
        {
            var alarma = await _context.Alarmas.FindAsync(id);

            if (alarma == null)
            {
                return NotFound();
            }

            return alarma;
        }

        // GET alarma/fecha/{fecha}
        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Alarma>>> GetAlarmaByFecha(DateTime fecha)
        {
            return await _context.Alarmas.Where(a => a.FechaHora.Date == fecha.Date).ToListAsync();
        }
    }
}