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
    public class SensorHumedadController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public SensorHumedadController(BiodigestorContext context)
        {
            _context = context;
        }

        // POST humedades
        [HttpPost]
        public async Task<ActionResult<SensorHumedad>> PostHumedad(SensorHumedad sensorHumedad)
        {
            _context.SensoresHumedad.Add(sensorHumedad);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHumedad), new { id = sensorHumedad.IdSensorHumedad }, sensorHumedad);
        }

        // GET humedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorHumedad>>> GetHumedades()
        {
            return await _context.SensoresHumedad.ToListAsync();
        }

        // GET humedades/{Fecha}
        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<SensorHumedad>>> GetHumedadesByFecha(DateTime fecha)
        {
            return await _context.SensoresHumedad.Where(t => t.FechaHoraH.Date == fecha.Date).ToListAsync();
        }

        // GET humedad/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorHumedad>> GetHumedad(int id)
        {
            var sensorHumedad = await _context.SensoresHumedad.FindAsync(id);

            if (sensorHumedad == null)
            {
                return NotFound();
            }

            return sensorHumedad;
        }
    }
}