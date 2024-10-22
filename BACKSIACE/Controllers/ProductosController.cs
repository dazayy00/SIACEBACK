using BACKSIACE.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BACKSIACE.Controllers
{
    [ApiController]
    [Route("api/productos/")]
    public class ProductosController : ControllerBase
    {
        private readonly SiaceDbContext _context;

        public ProductosController(SiaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoId }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, Producto producto)
        {
            if (id != producto.ProductoId) return BadRequest();
            _context.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
