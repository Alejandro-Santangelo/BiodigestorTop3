using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biodigestor.Model
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroFactura { get; set; }  // PK e Identity

        [Required]
        public DateTime FechaEmision { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; } = DateTime.Now.AddDays(15);


        [Required]
        public decimal ConsumoMensual { get; set; }

        [Required]
        public decimal ConsumoTotal { get; set; }

        // Clave foránea para Cliente
        public int NumeroCliente { get; set; }

        [JsonIgnore]
        [ForeignKey("NumeroCliente")]
        public Cliente? Cliente { get; set; }

        // Clave foránea para Domicilio
        public int NumeroMedidor { get; set; }

        [JsonIgnore]
        [ForeignKey("NumeroMedidor")]
        public Domicilio? Domicilio { get; set; }

         public Factura()
    {
        // Inicializar FechaVencimiento a 15 días desde hoy
        FechaVencimiento = DateTime.Now.AddDays(15);
    }
    }
}




