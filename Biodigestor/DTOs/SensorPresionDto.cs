// Models/SensorPresionUpdateDto.cs
using System.Text.Json.Serialization;

namespace Biodigestor.DTOs
{
    public class SensorPresionDto
    {
        
     public int IdSensor { get; set; }
    public int IdBiodigestor { get; set; }
    public DateTime FechaHora { get; set; }
    public double ValorLectura { get; set; }  // Lectura del sensor de presión
    
    }
}
