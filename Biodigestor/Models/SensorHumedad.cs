using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class SensorHumedad
    {
        [Key]
        public int IdSensorHumedad { get; set; }
        public int IdBiodigestor { get; set; }
        public decimal ValorLecturaH { get; set; }
        public DateTime FechaHoraH { get; set; }
    }
}