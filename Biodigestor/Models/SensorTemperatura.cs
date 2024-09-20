using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biodigestor.Models
{
    public class SensorTemperatura
    {
        [JsonIgnore]
        [Key]
        public int IdValorLectura { get; set; }
        public int IdBiodigestor { get; set; }
        
        public decimal? ValorLecturaT { get; set; }
        public DateTime FechaHoraT { get; set; }

        [JsonIgnore]
        public Biodigestor? Biodigestor { get; set; }
    }
}