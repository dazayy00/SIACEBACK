using BACKSIACE.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BACKSIACE.Controllers
{
    [ApiController]
    [Route("api/pedidos/")]
    public class PedidosController : ControllerBase
    {
        private readonly SiaceDbContext _context;

        public PedidosController(SiaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPedidos()
        {
            var pedidos = _context.Pedidos.ToList();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.PedidoId }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedido(int id, Pedido pedido)
        {
            if (id != pedido.PedidoId) return BadRequest();
            _context.Entry(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return NotFound();
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
