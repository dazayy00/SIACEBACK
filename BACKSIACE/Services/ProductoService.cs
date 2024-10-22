using BACKSIACE.Modelos;
using BACKSIACE.Repository;

namespace BACKSIACE.Services
{
    public class ProductoService
    {
        private readonly IRepository<Producto> _productoRepository;

        public ProductoService(IRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public IEnumerable<Producto> GetProductos()
        {
            return _productoRepository.GetAll();
        }

        public Producto GetProductoById(int id)
        {
            return _productoRepository.GetById(id);
        }

        public void CreateProducto(Producto producto)
        {
            _productoRepository.Add(producto);
            _productoRepository.Save();
        }

        public void UpdateProducto(Producto producto)
        {
            _productoRepository.Update(producto);
            _productoRepository.Save();
        }

        public void DeleteProducto(int id)
        {
            var producto = _productoRepository.GetById(id);
            if (producto != null)
            {
                _productoRepository.Delete(producto);
                _productoRepository.Save();
            }
        }
    }
}
