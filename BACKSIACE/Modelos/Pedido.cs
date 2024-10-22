using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BACKSIACE.Modelos
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Required]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Required]
        public int CantidadPedida { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; } = "Pendiente";

        [Required]
        public DateTime FechaPedido { get; set; } = DateTime.Now;
    }
}
