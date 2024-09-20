using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biodigestor.Models
{
    public class Biodigestor
    {
        [Key]
        public int IdBiodigestor { get; set; }
        public required string Descripcion { get; set; }
        public required string Estado { get; set; }
         
         [JsonIgnore]
        public ICollection<SensorTemperatura>? SensoresTemperatura { get; set; }
    }
}