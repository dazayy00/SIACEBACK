using BACKSIACE.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BACKSIACE.Controllers
{
    [ApiController]
    [Route("api/sucursal/")]
    public class SucursalesController : ControllerBase
    {
        private readonly SiaceDbContext _context;

        public SucursalesController(SiaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSucursales()
        {
            var sucursales = _context.Sucursales.ToList();
            return Ok(sucursales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSucursal(int id)
        {
            var sucursal = _context.Sucursales.Find(id);
            if (sucursal == null) return NotFound();
            return Ok(sucursal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.SucursalId }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSucursal(int id, Sucursal sucursal)
        {
            if (id != sucursal.SucursalId) return BadRequest();
            _context.Entry(sucursal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();
            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
