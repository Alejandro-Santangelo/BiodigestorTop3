using Biodigestor.DTOs;
using Microsoft.AspNetCore.Mvc;
using Biodigestor.Data;
using Biodigestor.Models;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimuladorDeValoresController : ControllerBase
{
    private readonly BiodigestorContext _context;

    public SimuladorDeValoresController(BiodigestorContext context)
    {
        _context = context;
    }

    // POST: api/SimuladorDeValores/Humedad
    [HttpPost("Humedad")]
    public async Task<ActionResult> PostSensorHumedad(SensorHumedadDto sensorHumedadDto)
    {
        var sensorHumedad = new SensorHumedad
        {
            IdBiodigestor = sensorHumedadDto.IdBiodigestor,
            ValorLectura = sensorHumedadDto.ValorLectura,
            FechaHora = sensorHumedadDto.FechaHora
        };

        _context.SensoresHumedad.Add(sensorHumedad);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostSensorHumedad), sensorHumedadDto);
    }

    // POST: api/SimuladorDeValores/Temperatura
    [HttpPost("Temperatura")]
    public async Task<ActionResult> PostSensorTemperatura(SensorTemperaturaDto sensorTemperaturaDto)
    {
        var sensorTemperatura = new SensorTemperatura
        {
            IdBiodigestor = sensorTemperaturaDto.IdBiodigestor,
            ValorLectura = sensorTemperaturaDto.ValorLectura,
            FechaHora = sensorTemperaturaDto.FechaHora
        };

        _context.SensoresTemperatura.Add(sensorTemperatura);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostSensorTemperatura), sensorTemperaturaDto);
    }

    // POST: api/SimuladorDeValores/Presion
    [HttpPost("Presion")]
    public async Task<ActionResult> PostSensorPresion(SensorPresionDto sensorPresionDto)
    {
        var sensorPresion = new SensorPresion
        {
            IdBiodigestor = sensorPresionDto.IdBiodigestor,
            ValorLectura = sensorPresionDto.ValorLectura,
            FechaHora = sensorPresionDto.FechaHora
        };

        _context.SensoresPresion.Add(sensorPresion);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostSensorPresion), sensorPresionDto);
    }
}