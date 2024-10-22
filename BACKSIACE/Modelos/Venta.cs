using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BACKSIACE.Modelos
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public DateTime FechaVenta { get; set; } = DateTime.Now;
    }
}
