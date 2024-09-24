// Models/SensorTemperaturaUpdateDto.cs
namespace Biodigestor.DTOs
{
    public class SensorTemperaturaDto
    {
        public int IdBiodigestor { get; set; } // Nuevo campo
        public decimal ValorLectura { get; set; }
        public DateTime FechaHora { get; set; }
    
    }
}


