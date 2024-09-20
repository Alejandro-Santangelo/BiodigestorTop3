using Biodigestor.Data;
using Biodigestor.Model;
using Biodigestor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("USUARIO ADMINISTRADOR/[controller]")]

//[ApiExplorerSettings(GroupName = "Usuario Administrador")]
public class FacturaController : ControllerBase
{
    private readonly BiodigestorContext _context;

    public FacturaController(BiodigestorContext context)
    {
        _context = context;
    }

    // POST: api/Facturas
    [HttpPost]
    public async Task<ActionResult<Factura>> PostFactura(Factura factura)
    {
        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFacturaByNumeroFactura), new { numeroFactura = factura.NumeroFactura }, factura);
    }

    // GET: api/Facturas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
    {
        return await _context.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Domicilio)
            .ToListAsync();
    }

    // GET: api/Facturas/{numeroFactura}
    [HttpGet("{numeroFactura}")]
    public async Task<ActionResult<Factura>> GetFacturaByNumeroFactura(int numeroFactura)
    {
        var factura = await _context.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Domicilio)
            .FirstOrDefaultAsync(f => f.NumeroFactura == numeroFactura);

        if (factura == null)
        {
            return NotFound();
        }

        return factura;
    }

    // GET: api/Facturas/cliente/{dni}
    [HttpGet("cliente/{dni}")]
    public async Task<ActionResult<IEnumerable<Factura>>> GetFacturasByDni(int dni)
    {
        var facturas = await _context.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Domicilio)
            .Where(f => f.Cliente != null && f.Cliente.DNI == dni)
            .ToListAsync();

        return facturas;
    }

    // GET: api/Facturas/domicilio/{numeroMedidor}
    [HttpGet("domicilio/{numeroMedidor}")]
    public async Task<ActionResult<IEnumerable<Factura>>> GetFacturasByNumeroMedidor(int numeroMedidor)
    {
        var facturas = await _context.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Domicilio)
            .Where(f => f.Domicilio != null && f.Domicilio.NumeroMedidor == numeroMedidor)
            .ToListAsync();

        return facturas;
    }
      
      // DELETE: api/Facturas/{numeroFactura}
[HttpDelete("{numeroFactura}")]
public async Task<IActionResult> DeleteFactura(int numeroFactura)
{
    // Buscar la factura por su número
    var factura = await _context.Facturas
        .Include(f => f.Cliente)
        .Include(f => f.Domicilio)
        .FirstOrDefaultAsync(f => f.NumeroFactura == numeroFactura);

    // Si no se encuentra, retornar NotFound
    if (factura == null)
    {
        return NotFound();
    }

    // Eliminar la factura
    _context.Facturas.Remove(factura);
    await _context.SaveChangesAsync();

    // Retornar NoContent para indicar que la operación fue exitosa
    return NoContent();
}

}

