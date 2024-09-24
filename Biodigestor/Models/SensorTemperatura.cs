using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Asegúrate de tener esta línea
using System.Text.Json.Serialization;

namespace Biodigestor.Models
{
    public class SensorTemperatura
{
    [Key]
    public int IdSensorTemperatura { get; set; }
    public int IdBiodigestor { get; set; }
    public decimal ValorLectura { get; set; }
    public DateTime FechaHora { get; set; }
}
}
