using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class Alarma
    {
        [Key]
        public int IdAlarma { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime HoraAlarma { get; set; }
        public string? SensorAlarma { get; set; }
    }
}