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

        // POST sensorPresion
        [HttpPost]
        // POST sensorPresion
[HttpPost]
public async Task<ActionResult<SensorPresion>> PostSensorPresion(SensorPresion sensorPresion)
{
    _context.SensoresPresion.Add(sensorPresion);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetSensorPresion), new { id = sensorPresion.IdSensorPresion }, sensorPresion);
}

        // GET sensorPresions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorPresion>>> GetSensorPresions()
        {
            return await _context.SensoresPresion.ToListAsync();
        }

        // GET sensorPresions/{Fecha}
        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<SensorPresion>>> GetSensorPresionsByFecha(DateTime fecha)
        {
            return await _context.SensoresPresion.Where(t => t.FechaHoraP.Date == fecha.Date).ToListAsync();
        }

        // GET sensorPresion/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorPresion>> GetSensorPresion(int id)
        {
            var sensorPresion = await _context.SensoresPresion.FindAsync(id);

            if (sensorPresion == null)
            {
                return NotFound();
            }

            return sensorPresion;
        }
    }
}