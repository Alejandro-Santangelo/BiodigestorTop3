using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Biodigestor.Models;
using Microsoft.EntityFrameworkCore;
using Biodigestor.Data;

namespace TuProyecto.Controllers.SimuladorValores
{ /*
    [ApiController]
    [Route("api/[controller]")]
    public class SimuladorValoresController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public SimuladorValoresController(BiodigestorContext context)
        {
            _context = context;
        }

        // POST api/simuladorvalores/sensorhumedad/{id}
        [HttpPost("sensorhumedad/{id}")]
        public async Task<IActionResult> PostSensorHumedad(int id, [FromBody] SensorHumedadUpdateDto sensorHumedadDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crear un nuevo sensor de humedad
            var nuevoSensorHumedad = new SensorHumedad
            {
                ValorLecturaH = sensorHumedadDto.ValorLecturaH ?? 0m,
                FechaHoraH = sensorHumedadDto.FechaHoraH,
                IdBiodigestor = sensorHumedadDto.IdBiodigestor // Asignar el IdBiodigestor
            };

            _context.SensoresHumedad.Add(nuevoSensorHumedad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSensorHumedad), new { id = nuevoSensorHumedad.IdSensorHumedad }, nuevoSensorHumedad);
        }

        // POST api/simuladorvalores/sensortemperatura/{id}
        [HttpPost("sensortemperatura/{id}")]
        public async Task<IActionResult> PostSensorTemperatura(int id, [FromBody] SensorTemperaturaUpdateDto sensorTemperaturaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crear un nuevo sensor de temperatura
            var nuevoSensorTemperatura = new SensorTemperatura
            {
                ValorLecturaT = sensorTemperaturaDto.ValorLecturaT,
                FechaHoraT = sensorTemperaturaDto.FechaHoraT,
                IdBiodigestor = sensorTemperaturaDto.IdBiodigestor // Asignar el IdBiodigestor
            };

            _context.SensoresTemperatura.Add(nuevoSensorTemperatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSensorTemperatura), new { id = nuevoSensorTemperatura.IdSensorTemperatura }, nuevoSensorTemperatura);
        }
         
        // POST api/simuladorvalores/sensorpresion/{id}
        [HttpPost("sensorpresion/{id}")]
        public async Task<IActionResult> PostSensorPresion(int id, [FromBody] SensorPresionUpdateDto sensorPresionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crear un nuevo sensor de presión
            var nuevoSensorPresion = new SensorPresion
            {
                ValorLecturaP = sensorPresionDto.ValorLecturaP,
                FechaHoraP = sensorPresionDto.FechaHoraP,
                IdBiodigestor = sensorPresionDto.IdBiodigestor // Asignar el IdBiodigestor
            };

            _context.SensoresPresion.Add(nuevoSensorPresion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSensorPresion), new { id = nuevoSensorPresion.IdSensorPresion }, nuevoSensorPresion);
        }
    }
    */ 
}

