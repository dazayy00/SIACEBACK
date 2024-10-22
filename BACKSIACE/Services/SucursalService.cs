using BACKSIACE.Modelos;
using BACKSIACE.Repository;

namespace BACKSIACE.Services
{
    public class SucursalService
    {
        private readonly IRepository<Sucursal> _sucursalRepository;

        public SucursalService(IRepository<Sucursal> sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public IEnumerable<Sucursal> GetSucursales()
        {
            return _sucursalRepository.GetAll();
        }

        public Sucursal GetSucursalById(int id)
        {
            return _sucursalRepository.GetById(id);
        }

        public void CreateSucursal(Sucursal sucursal)
        {
            _sucursalRepository.Add(sucursal);
            _sucursalRepository.Save();
        }

        public void UpdateSucursal(Sucursal sucursal)
        {
            _sucursalRepository.Update(sucursal);
            _sucursalRepository.Save();
        }

        public void DeleteSucursal(int id)
        {
            var sucursal = _sucursalRepository.GetById(id);
            if (sucursal != null)
            {
                _sucursalRepository.Delete(sucursal);
                _sucursalRepository.Save();
            }
        }
    }
}
