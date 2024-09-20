using System.ComponentModel.DataAnnotations;

namespace Biodigestor.DTOs
{
   public class FacturaDto
{
    [Required]
    public int NumeroFactura { get; set; }

    [Required]
    public DateTime FechaEmision { get; set; }

    [Required]
    public DateTime FechaVencimiento { get; set; }

    [Required]
    public decimal ConsumoMensual { get; set; }

    [Required]
    public decimal ConsumoTotal { get; set; }

     public FacturaDto()
    {
        // Inicializar FechaVencimiento a 15 días desde hoy
        FechaVencimiento = DateTime.Now.AddDays(15);
    }
}
}

