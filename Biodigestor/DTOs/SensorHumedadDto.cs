// Models/SensorHumedadUpdateDto.cs
using System.Text.Json.Serialization;

namespace Biodigestor.DTOs
{
    public class SensorHumedadDto
    {
        public int IdBiodigestor { get; set; } // Nuevo campo

        
        public decimal ValorLectura { get; set; }
        public DateTime FechaHora { get; set; }
    
    }
}
