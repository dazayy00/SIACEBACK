using BACKSIACE.Modelos;
using BACKSIACE.Repository;

namespace BACKSIACE.Services
{
    public class ReporteService
    {
        private readonly IRepository<Reporte> _reporteRepository;

        public ReporteService(IRepository<Reporte> reporteRepository)
        {
            _reporteRepository = reporteRepository;
        }

        public IEnumerable<Reporte> GetReportes()
        {
            return _reporteRepository.GetAll();
        }

        public Reporte GetReporteById(int id)
        {
            return _reporteRepository.GetById(id);
        }

        public void CreateReporte(Reporte reporte)
        {
            _reporteRepository.Add(reporte);
            _reporteRepository.Save();
        }

        public void UpdateReporte(Reporte reporte)
        {
            _reporteRepository.Update(reporte);
            _reporteRepository.Save();
        }

        public void DeleteReporte(int id)
        {
            var reporte = _reporteRepository.GetById(id);
            if (reporte != null)
            {
                _reporteRepository.Delete(reporte);
                _reporteRepository.Save();
            }
        }
    }
}
