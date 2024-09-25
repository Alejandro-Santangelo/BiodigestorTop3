// Models/SensorTemperaturaUpdateDto.cs
namespace Biodigestor.DTOs
{
    public class SensorTemperaturaDto
    {
         public int IdSensor { get; set; }
    public int IdBiodigestor { get; set; }
    public DateTime FechaHora { get; set; }
    public double ValorLectura { get; set; }  // Lectura del sensor de temperatura
    
    }
}


