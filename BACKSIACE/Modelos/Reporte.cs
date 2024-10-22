using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BACKSIACE.Modelos
{
    public class Reporte
    {
        [Key]
        public int ReporteId { get; set; }

        [Required]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        [Required]
        public DateTime FechaReporte { get; set; }

        [Required]
        public decimal TotalVentas { get; set; }
    }
}
