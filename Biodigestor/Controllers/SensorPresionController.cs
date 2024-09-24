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
    public class SensorPresionController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public SensorPresionController(BiodigestorContext context)
        {
            _context = context;
        }

        // POST presion
        [HttpPost]
        public async Task<ActionResult<SensorPresion>> PostPresion(SensorPresion sensorPresion)
        {
            _context.SensoresPresion.Add(sensorPresion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPresion), new { id = sensorPresion.IdSensorPresion }, sensorPresion);
        }

        // GET presion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorPresion>>> GetPresiones()
        {
            return await _context.SensoresPresion.ToListAsync();
        }

        // GET presion/{fecha}
        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<SensorPresion>>> GetPresionesByFecha(DateTime fecha)
        {
            return await _context.SensoresPresion
                .Where(t => t.FechaHora.Date == fecha.Date)
                .ToListAsync();
        }

        // GET presion/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorPresion>> GetPresion(int id)
        {
            var sensorPresion = await _context.SensoresPresion.FindAsync(id);

            if (sensorPresion == null)
            {
                return NotFound();
            }

            return sensorPresion;
        }

        // PUT presion/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresion(int id, SensorPresion sensorPresion)
        {
            if (id != sensorPresion.IdSensorPresion)
            {
                return BadRequest();
            }

            _context.Entry(sensorPresion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorPresionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE presion/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresion(int id)
        {
            var sensorPresion = await _context.SensoresPresion.FindAsync(id);
            if (sensorPresion == null)
            {
                return NotFound();
            }

            _context.SensoresPresion.Remove(sensorPresion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensorPresionExists(int id)
        {
            return _context.SensoresPresion.Any(e => e.IdSensorPresion == id);
        }
    }
}

