using BACKSIACE.Modelos;
using BACKSIACE.Repository;

namespace BACKSIACE.Services
{
    public class VentaService
    {
        private readonly IRepository<Venta> _ventaRepository;

        public VentaService(IRepository<Venta> ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public IEnumerable<Venta> GetVentas()
        {
            return _ventaRepository.GetAll();
        }

        public Venta GetVentaById(int id)
        {
            return _ventaRepository.GetById(id);
        }

        public void CreateVenta(Venta venta)
        {
            _ventaRepository.Add(venta);
            _ventaRepository.Save();
        }

        public void UpdateVenta(Venta venta)
        {
            _ventaRepository.Update(venta);
            _ventaRepository.Save();
        }

        public void DeleteVenta(int id)
        {
            var venta = _ventaRepository.GetById(id);
            if (venta != null)
            {
                _ventaRepository.Delete(venta);
                _ventaRepository.Save();
            }
        }
    }
}
