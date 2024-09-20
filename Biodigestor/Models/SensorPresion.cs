using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class SensorPresion
    {
        [Key]
        public int IdSensorPresion { get; set; }
        public int IdBiodigestor { get; set; }
        public decimal ValorLecturaP { get; set; }
        public DateTime FechaHoraP { get; set; }
    }
}