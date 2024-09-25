using System;
using System.ComponentModel.DataAnnotations;

namespace Biodigestor.DTOs
{
    public class SensorHumedadDto
    {
        [Required]
        public int IdSensor { get; set; }

        [Required]
        public int IdBiodigestor { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

       // [Required]
        //[Range(0, 100)] // Ajusta el rango según sea necesario
        public double ValorLectura { get; set; }  // Lectura del sensor de humedad
    }
}

