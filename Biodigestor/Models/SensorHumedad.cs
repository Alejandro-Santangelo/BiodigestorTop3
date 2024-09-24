using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biodigestor.Models
{
   public class SensorHumedad
{
    [Key]
    public int IdSensorHumedad { get; set; }
    public int IdBiodigestor { get; set; }
    public decimal ValorLectura { get; set; }
    public DateTime FechaHora { get; set; }
}
}