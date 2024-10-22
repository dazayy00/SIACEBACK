using BACKSIACE.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BACKSIACE
{
    public class SiaceDbContext : DbContext
    {
        public SiaceDbContext(DbContextOptions<SiaceDbContext> options) : base(options) { }

        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }

}
