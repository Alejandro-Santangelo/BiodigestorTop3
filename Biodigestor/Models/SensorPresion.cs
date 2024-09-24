using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
   public class SensorPresion
{
    [Key]
    public int IdSensorPresion { get; set; }
    public int IdBiodigestor { get; set; }
    public decimal ValorLectura { get; set; }
    public DateTime FechaHora { get; set; }
}
}