using System.ComponentModel.DataAnnotations;

namespace BACKSIACE.Modelos
{
    public class Sucursal
    {
        [Key]
        public int SucursalId { get; set; }

        [Required]
        [MaxLength(100)]
        public String Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public String Direccion { get; set; }

        [MaxLength(10)]
        public String Telefono { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
