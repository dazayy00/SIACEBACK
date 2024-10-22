using BACKSIACE.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BACKSIACE.Controllers
{
    [ApiController]
    [Route("api/venta/")]
    public class VentasController : ControllerBase
    {
        private readonly SiaceDbContext _context;

        public VentasController(SiaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVentas()
        {
            var ventas = _context.Ventas.ToList();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public IActionResult GetVenta(int id)
        {
            var venta = _context.Ventas.Find(id);
            if (venta == null) return NotFound();
            return Ok(venta);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVenta), new { id = venta.VentaId }, venta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenta(int id, Venta venta)
        {
            if (id != venta.VentaId) return BadRequest();
            _context.Entry(venta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null) return NotFound();
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
