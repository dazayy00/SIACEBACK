using System.ComponentModel.DataAnnotations;

namespace BACKSIACE.Modelos
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public int Stock { get; set; } = 0;

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
