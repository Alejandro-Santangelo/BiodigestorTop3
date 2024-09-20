using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class Alerta
    {
        [Key]
        public int IdAlerta
         { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime HoraAlerta { get; set; }
        public string? SensorAlerta { get; internal set; }
    }
}