using BACKSIACE.Modelos;
using BACKSIACE.Repository;

namespace BACKSIACE.Services
{
    public class PedidoService
    {
        private readonly IRepository<Pedido> _pedidoRepository;

        public PedidoService(IRepository<Pedido> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IEnumerable<Pedido> GetPedidos()
        {
            return _pedidoRepository.GetAll();
        }

        public Pedido GetPedidoById(int id)
        {
            return _pedidoRepository.GetById(id);
        }

        public void CreatePedido(Pedido pedido)
        {
            _pedidoRepository.Add(pedido);
            _pedidoRepository.Save();
        }

        public void UpdatePedido(Pedido pedido)
        {
            _pedidoRepository.Update(pedido);
            _pedidoRepository.Save();
        }

        public void DeletePedido(int id)
        {
            var pedido = _pedidoRepository.GetById(id);
            if (pedido != null)
            {
                _pedidoRepository.Delete(pedido);
                _pedidoRepository.Save();
            }
        }
    }
}
