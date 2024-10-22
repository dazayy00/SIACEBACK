using BACKSIACE.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BACKSIACE.Controllers
{
    [ApiController]
    [Route("api/reportes/")]
    public class ReportesController : ControllerBase
    {
        private readonly SiaceDbContext _context;

        public ReportesController(SiaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetReportes()
        {
            var reportes = _context.Reportes.ToList();
            return Ok(reportes);
        }

        [HttpGet("{id}")]
        public IActionResult GetReporte(int id)
        {
            var reporte = _context.Reportes.Find(id);
            if (reporte == null) return NotFound();
            return Ok(reporte);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReporte(Reporte reporte)
        {
            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReporte), new { id = reporte.ReporteId }, reporte);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReporte(int id, Reporte reporte)
        {
            if (id != reporte.ReporteId) return BadRequest();
            _context.Entry(reporte).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporte(int id)
        {
            var reporte = await _context.Reportes.FindAsync(id);
            if (reporte == null) return NotFound();
            _context.Reportes.Remove(reporte);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
