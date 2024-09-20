using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biodigestor.Models;
using Biodigestor.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Biodigestor.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Route("api/[controller]")]
    public class SensorTemperaturaController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public SensorTemperaturaController(BiodigestorContext context)
        {
            _context = context;
        }

        // POST temperaturas
        [HttpPost]
        public async Task<ActionResult<SensorTemperatura>> PostSensorTemperatura(SensorTemperatura sensorTemperatura)
        {
            _context.SensoresTemperatura.Add(sensorTemperatura);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSensorTemperatura), new { id = sensorTemperatura.IdValorLectura }, sensorTemperatura);
        }

        // POST simulación con alerta (sin DTO)
        [HttpPost("SIMULAR  LECTURAS")]
        public async Task<IActionResult> SimularSensorTemperatura([FromBody] SensorTemperatura sensorTemperatura)
        {
            // Asignar automáticamente la fecha y hora actual
            sensorTemperatura.FechaHoraT = DateTime.UtcNow;

            // Agregar la entidad SensorTemperatura a la base de datos
            _context.SensoresTemperatura.Add(sensorTemperatura);
            await _context.SaveChangesAsync();

            // Verificar el valor y tomar las acciones correspondientes
            if (sensorTemperatura.ValorLecturaT < 20)
            {
                // Crear alerta para "Calentador Encendido"
                var alerta = new Alerta
                {
                    HoraAlerta = DateTime.UtcNow,
                    SensorAlerta = sensorTemperatura.IdValorLectura.ToString()
                };
                _context.Alertas.Add(alerta);
            }
            else if (sensorTemperatura.ValorLecturaT >= 20 && sensorTemperatura.ValorLecturaT < 60)
            {
                // Crear alerta para "Advertencia Temperatura Elevada"
                var alerta = new Alerta
                {
                    HoraAlerta = DateTime.UtcNow,
                    SensorAlerta = sensorTemperatura.IdValorLectura.ToString()
                };
                _context.Alertas.Add(alerta);
            }
            else if (sensorTemperatura.ValorLecturaT >= 60)
            {
                // Crear alarma para "Alarma Temperatura Muy Alta"
                var alarma = new Alarma
                {
                    HoraAlarma = DateTime.UtcNow,
                    SensorAlarma = sensorTemperatura.IdValorLectura.ToString()
                };
                _context.Alarmas.Add(alarma);
            }

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();

            // Retornar la entidad creada
            return Ok(sensorTemperatura);
        }

        // GET temperaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorTemperatura>>> GetSensorTemperaturas()
        {
            return await _context.SensoresTemperatura.ToListAsync();
        }

        // GET temperaturas/{Fecha}
        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<SensorTemperatura>>> GetSensorTemperaturasByFecha(DateTime fecha)
        {
            return await _context.SensoresTemperatura
                .Where(t => t.FechaHoraT.Date == fecha.Date)
                .ToListAsync();
        }

        // GET temperaturas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorTemperatura>> GetSensorTemperatura(int id)
        {
            var sensorTemperatura = await _context.SensoresTemperatura.FindAsync(id);

            if (sensorTemperatura == null)
            {
                return NotFound();
            }

            return sensorTemperatura;
        }
    }
}

